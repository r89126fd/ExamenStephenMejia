using System;
using System.Globalization;

namespace Examen
{
    class Alumno
    {
        public string NombreAlumno { get; set; }
        public string NombreCuenta { get; set; }
        public string Email { get; set; }
    }
    interface IAsignatura
    {
        double CalcularNotaFinal();
        double CalcularNotaFinal(int n1, int n2, int n3);
        string MensajeNotaFinal(double notaFinal);
        void Imprimir();
    }

    class Asignatura : Alumno, IAsignatura
    {
        public int N1 { get; set; }
        public int N2 { get; set; }
        public int N3 { get; set; }
        public string NombreAsignatura { get; set; }
        public string Horario { get; set; }
        public string NombreDocente { get; set; }

        public double CalcularNotaFinal()
        {
            return N1 + N2 + N3;
        }

        public double CalcularNotaFinal(int n1, int n2, int n3)
        {
            return n1 + n2 + n3;
        }
        public string MensajeNotaFinal(double notaFinal)
        {
            if (notaFinal <= 59)
                return "Reprobado";
            else if (notaFinal <= 79)
                return "Bueno";
            else if (notaFinal <= 89)
                return "Muy Bueno";
            else
                return "Sobresaliente";
        }
        public void Imprimir()
        {
            double notaFinal1 = CalcularNotaFinal();
            double notaFinal2 = CalcularNotaFinal(N1, N2, N3);
            string mensaje = MensajeNotaFinal(notaFinal1);


            Console.WriteLine("***************************************************");
            Console.WriteLine($"Nombre del estudiante: {NombreAlumno}");
            Console.WriteLine($"Número de cuenta: {NombreCuenta}");
            Console.WriteLine($"Correo electrónico: {Email}");
            Console.WriteLine($"Nombre de la clase: {NombreAsignatura}");
            Console.WriteLine($"Horario: {Horario}");
            Console.WriteLine($"Nombre del docente: {NombreDocente}");
            Console.WriteLine($"Nota final: {notaFinal1}% - {mensaje}");
            Console.WriteLine($"Nota final: {notaFinal2}% - {mensaje}");
            Console.WriteLine("***************************************************");
        }
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Asignatura asignatura = new Asignatura();
                    Console.WriteLine("Ingrese nombre del alumno: ");
                    asignatura.NombreAlumno = Console.ReadLine();

                    Console.WriteLine("Ingrese numero de cuenta: ");
                    asignatura.NombreCuenta = Console.ReadLine();

                    Console.WriteLine("Ingrese correo electronico: ");
                    asignatura.Email = Console.ReadLine();

                    Console.WriteLine("Ingrese nombre de la clase: ");
                    asignatura.NombreAsignatura = Console.ReadLine();

                    Console.WriteLine("Ingrese el horario: ");
                    asignatura.Horario = Console.ReadLine();

                    Console.WriteLine("Ingrese el nombre del docente: ");
                    asignatura.NombreDocente = Console.ReadLine();

                    Console.WriteLine("Ingrese nota del primer parcial (maximo 30): ");
                    asignatura.N1 = LeerNota(30);

                    Console.WriteLine("Ingrese la nota del segundo parcial (maximo 30): ");
                    asignatura.N2 = LeerNota(30);

                    Console.WriteLine("Ingrese la nota del tercer parcial (maximo 40): ");
                    asignatura.N3 = LeerNota(40);

                    asignatura.Imprimir();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Una de las notas ingresadas no es valida ");
                }
            }
            static int LeerNota(int maximo)
            {
                int nota = int.Parse(Console.ReadLine());
                if (nota < 0 || nota > maximo)
                    throw new FormatException();
                return nota;
            }
        }
    }
}