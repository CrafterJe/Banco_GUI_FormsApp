using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto_GUI_BancoUTP
{
    internal class Usuarios
    {
        private string connectionString = "server=localhost;database=banco_utp;user=root;";
        public int Id { get; private set; }  // Propiedad para almacenar el ID
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Nombre { get; private set; }
        public static Usuarios UsuarioActual { get; set; }

        // Constructor vacío
        public Usuarios() { }

        // Constructor que toma el nombre de usuario y la contraseña
        public Usuarios(string username, string password)
        {
            Username = username;
            Password = password;
            if (!VerificarCredenciales(username, password))
            {
                throw new Exception("Usuario o contraseña incorrectos.");
            }
        }

        // Método para verificar credenciales
        public bool VerificarCredenciales(string username, string password)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, nombre FROM Usuarios WHERE username = @username AND password = SHA2(@password, 256)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Id = Convert.ToInt32(reader["id"]); // Asignar el ID al usuario
                            Nombre = reader["nombre"].ToString();
                            return true; // Credenciales válidas
                        }
                        else
                        {
                            return false; // Credenciales inválidas
                        }
                    }
                }
            }
        }

        // Método para consultar el saldo
        public double ConsultarSaldo()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT saldo FROM Usuarios WHERE id = @id"; // Cambiado a usar el ID

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", Id);
                    return Convert.ToDouble(command.ExecuteScalar());
                }
            }
        }

        // Método para abonar saldo
        public void AbonarSaldo(double cantidad)
        {
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad a abonar debe ser positiva.");
            }

            double nuevoSaldo = ConsultarSaldo() + cantidad;
            ActualizarSaldo(nuevoSaldo);
        }

        // Método para retirar saldo
        public void RetirarSaldo(double cantidad)
        {
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad a retirar debe ser positiva.");
            }

            double saldoActual = ConsultarSaldo();
            if (cantidad > saldoActual)
            {
                throw new InvalidOperationException("Saldo insuficiente.");
            }

            double nuevoSaldo = saldoActual - cantidad;
            ActualizarSaldo(nuevoSaldo);
        }

        // Método privado para actualizar saldo
        private void ActualizarSaldo(double nuevoSaldo)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Usuarios SET saldo = @saldo WHERE id = @id"; // Cambiado a usar el ID

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@saldo", nuevoSaldo);
                    command.Parameters.AddWithValue("@id", Id); // Cambiado a usar el ID
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para crear un nuevo usuario
        public void CrearUsuario(string username, string password, string nombre)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("Todos los campos son obligatorios.");
            }

            // Encriptar la contraseña
            string hashedPassword = HashPassword(password);

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Usuarios (username, password, nombre, saldo) VALUES (@username, @password, @nombre, 0)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", hashedPassword);
                    command.Parameters.AddWithValue("@nombre", nombre);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para encriptar la contraseña
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant(); // Convertir a string hexadecimal
            }
        }

        // Método para obtener transacciones del usuario actual
        public List<Transaccion> ObtenerTransacciones()
        {
            List<Transaccion> transacciones = new List<Transaccion>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT monto, tipo, fecha FROM Transacciones WHERE usuario_id = @usuarioId"; // Incluida la fecha

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@usuarioId", Id); // Usar el ID del usuario actual

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            transacciones.Add(new Transaccion
                            {
                                Monto = Convert.ToDouble(reader["monto"]),
                                Tipo = reader["tipo"].ToString(),
                                Fecha = Convert.ToDateTime(reader["fecha"]) // Asignada la fecha
                            });
                        }
                    }
                }
            }

            return transacciones;
        }


        // Clase interna para las transacciones
        public class Transaccion
        {
            public double Monto { get; set; }
            public string Tipo { get; set; }
            public DateTime Fecha { get; set; } 
        }

        public void RegistrarTransaccion(double monto, string tipo)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Transacciones (usuario_id, monto, tipo, fecha) VALUES (@usuarioId, @monto, @tipo, NOW())";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@usuarioId", Id); // Usa la propiedad Id del usuario actual
                    command.Parameters.AddWithValue("@monto", monto);
                    command.Parameters.AddWithValue("@tipo", tipo);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

