# BancoUTP - Aplicación de Banco

**Creado por Raúl Juárez Suárez**

La aplicación **BancoUTP** es un sistema bancario que permite la gestión de cuentas, transacciones y pagos de servicios. Está desarrollada en **C#** y utiliza **MySQL** como base de datos.

## Características principales

- **Registro de usuario**: Permite registrar una cuenta con matrícula, nombre completo y un PIN de seguridad.
- **Depósitos y retiros**: Los usuarios pueden depositar y retirar dinero de su cuenta.
- **Visualización de saldo**: Permite consultar el saldo disponible en la cuenta.
- **Historial de transacciones**: Muestra un registro de todas las transacciones realizadas.
- **Pago de servicios**: Posibilidad de pagar servicios directamente desde la cuenta.
- **Seguridad**: Uso de PIN para autenticación y protección de cuenta.

## Requisitos

Antes de ejecutar la aplicación, asegúrate de tener instalado:

- **.NET Framework** (versión compatible con la aplicación)
- **MySQL Server**
- **MySQL Connector para .NET**

## Instalación

1. **Clonar el repositorio**

   ```bash
   git clone https://github.com/tu-repositorio.git
   cd Proyecto_GUI_BancoUTP
   ```

2. **Configurar la base de datos**

   - Importa el archivo `banco_utp.sql` en tu servidor MySQL.
   - Asegúrate de configurar la conexión a la base de datos en la aplicación.

3. **Ejecutar la aplicación**

   - Abre el proyecto en **Visual Studio**.
   - Compila y ejecuta el programa.

## Base de datos

La aplicación se conecta a una base de datos MySQL llamada `banco_utp.sql`, que contiene las siguientes tablas principales:

- `Usuarios`: Almacena matrícula, nombre, PIN y saldo.
- `Transacciones`: Registra depósitos, retiros y pagos.
- `Casos`: Guarda información sobre problemas o consultas de los usuarios.

## Uso de la aplicación

1. **Registro**: Ingresa una matrícula, nombre y PIN para crear una cuenta.
2. **Inicio de sesión**: Usa la matrícula y PIN para acceder a tu cuenta.
3. **Depósitos y retiros**: Agrega o retira dinero de tu cuenta.
4. **Consultar saldo**: Verifica cuánto dinero tienes disponible.
5. **Historial de transacciones**: Revisa los movimientos de tu cuenta.
6. **Pago de servicios**: Realiza pagos de facturas y servicios desde la aplicación.

## Recursos adicionales

Si tienes dudas o necesitas ayuda, revisa la documentación del código o contacta al equipo de desarrollo.
