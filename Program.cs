using System;

class Program
{
    static void Main(string[] args)
    {


        //TiposFecha();

        //Primer ejercicio
        //Calcular la edad de una persona:
        //CalcularEdad();
        //ñoBisiesto();
        //NombreMesActual();
        SumarDias();
    }
    static void CalcularEdad()
    {
        DateTime fechaNacimiento = new DateTime(1990, 5, 10);
        DateTime fechaActual = DateTime.Now;

        int edad = fechaActual.Year - fechaNacimiento.Year;

    }
    static void TiposFecha()
    {

        DateTime fechaNacimiento = new DateTime();
        //Console.WriteLine($"Probando Fechas {fechaNacimiento}");
        //salida:
        //Probando Fechas 01/01/0001 00:00:00


        fechaNacimiento = new DateTime(1999, 4, 1);
        var fechaActual = DateTime.Now;
        //Console.WriteLine($"Probando Fechas {fechaNacimiento}");
        //salida:
        //Probando Fechas 01/04/1999 00:00:00

        Console.WriteLine($"Probando Fechas {fechaNacimiento.ToString("dd/MM/yyyy")}");
        Console.WriteLine($"La fecha actual {fechaActual.ToString("d/M/yy")}");

        //calcular la diferencia entre dos fechas
        var diferenciaDeFechas = fechaActual - fechaNacimiento;
        Console.WriteLine($"la diferencia {diferenciaDeFechas.Days / 365}");


    }

    static void AñoBisiesto()
    {

        int Year = DateTime.Now.Year;

        while (!DateTime.IsLeapYear(Year))
        {
            Year = Year - 1;
        }


        if (!DateTime.IsLeapYear(Year))
        {
            Console.WriteLine($"El año {Year} no es bisiesto");
        }
        else
        {
            Console.WriteLine($"Este año {Year} es bisiesto");
        }



    }

    static void NombreMesActual()
    {
        DateTime fechaActual = DateTime.Now;
        string mes = fechaActual.ToString("MMMM");
        Console.WriteLine($"Nombre del mes actual {mes}");


    }

    static void SumarDias()
    {
        Console.WriteLine("Ingrese la cantidad de días a sumar a la fecha actual: ");
        //para agregar 1 1/2 de dia, es con double y con int para numero enteros
        //int dias = int.Parse(Console.ReadLine());
        double dias = double.Parse(Console.ReadLine());

        DateTime fechaActual = DateTime.Now;
        DateTime fechaFinal = fechaActual.AddDays(dias);

        string fechaFormateada = fechaActual.ToString("MM/dd/yyyy");
        string fechaFinalFormateada = fechaFinal.ToString("MM/dd/yyyy");

        Console.WriteLine($"La fecha actual es: {fechaFormateada}");
        Console.WriteLine($"Sumando {dias} días a la fecha actual, la fecha resultante es: {fechaFinalFormateada}");

    }
}
