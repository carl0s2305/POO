internal class Program
{

    public class menu
    {
        static int mostrarMenu()
        {
            Console.WriteLine("MENU\n1. Ingresar Libro.\n2. Prestar libro\n3. Devolver libro\n4. Mostrar libros prestados\n5. Listar todos los libros\n6. Salir\n\nSeleccione una opcion:");
            return (int.Parse(Console.ReadLine()));
        }
    public class libro
    {
            int anhO, statuS, j = 0;
            string nombrE, editoriaL, autoR;
            public string nombre { get; set; }
            public string editorial { get; set; }
            public string autor { get; set; }
            public int anho { get; set; }
            public int status { get; set; }

            List<libro> libros = new List<libro>();

        public void ingresarLibro()
        {
                Console.WriteLine("\nDATOS DEL LIBRO:\nNombre del libro: ");
                nombrE = Console.ReadLine();

                for (int i = 0; i < libros.Count; i++)
                {
                    if (libros[i].nombre.Equals(nombrE.ToUpper()))
                    {
                        j = (j+1);
                    }
                }
                
                if(j > 0)
                {
                    Console.WriteLine("\nEl libro " + nombrE.ToUpper() + " ya esta registrado.\n");
                }
                else
                {
                    Console.WriteLine("Autor del libro: ");
                    autoR = Console.ReadLine();

                    Console.WriteLine("Editorial del libro: ");
                    editoriaL = Console.ReadLine();

                    Console.WriteLine("Año de lanzamiento del libro: ");
                    anhO = int.Parse(Console.ReadLine());

                    Console.WriteLine("");

                    libros.Add(new libro() { nombre = nombrE.ToUpper(), editorial = editoriaL.ToUpper(), autor = autoR.ToUpper(), anho = anhO, status = 0 });
                }
        }
            public void prestarLibro()
            {
                Console.WriteLine("\nEscriba el nombre del libro que quiera prestar: ");
                nombrE = Console.ReadLine();
                Console.WriteLine("");

                List<libro> librosFilter = libros.Where(item => item.nombre == nombrE.ToUpper() ).ToList();

                if (librosFilter[0].status != 1)
                {
                    libros.Remove(librosFilter[0]);
                    libros.Add(new libro() { nombre = librosFilter[0].nombre, editorial = librosFilter[0].editorial, autor = librosFilter[0].autor, anho = librosFilter[0].anho, status = 1 }); ;
                }
                else
                {
                    Console.WriteLine("\nEl libro " + librosFilter[0].nombre + " ya esta prestado.\n");
                }
            }

            public void devolverLibro()
            {
                Console.WriteLine("\nEscriba el nombre del libro que quiera devolver: ");
                nombrE = Console.ReadLine();

                List<libro> librosFilter = libros.Where(item => item.nombre == nombrE.ToUpper()).ToList();

                if (librosFilter[0].status == 1)
                {
                    libros.Remove(librosFilter[0]);
                    libros.Add(new libro() { nombre = librosFilter[0].nombre, editorial = librosFilter[0].editorial, autor = librosFilter[0].autor, anho = librosFilter[0].anho, status = 2 });
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("\nEl libro " + librosFilter[0].nombre + " no esta prestado.\n");
                }
            }
            public void printarLibrosPrestados()
            {
                List<libro> librosFilter = libros.Where(item => item.status == 1).ToList();

                for (int i = 0; i < librosFilter.Count; i++)
                {
                    Console.WriteLine("\nLibro " + (i + 1) + "\nNombre: " + librosFilter[i].nombre + "\nAutor: " + librosFilter[i].autor + "\nEditorial: " + librosFilter[i].editorial + ", " + librosFilter[i].anho + ".");
                }

                Console.WriteLine("");
            }
            public void printarLibros()
        {
            for (int i = 0; i < libros.Count; i++)
                {
                    Console.WriteLine("\nLibro " + (i+1) + "\nNombre: " + libros[i].nombre + "\nAutor: " + libros[i].autor + "\nEditorial: " + libros[i].editorial + ", " + libros[i].anho + ".");
                }

                Console.WriteLine("");
            }
    }

        private static void Main(string[] args)
        {
            libro objLibro = new libro();
            menu objMenu = new menu();

            int optiOn;

            optiOn = mostrarMenu();

            do
            {
                if (optiOn >0 && optiOn < 7)
                {
                    switch (optiOn)
                    {
                        case 1:
                            objLibro.ingresarLibro();
                            break;
                        case 2:
                            objLibro.prestarLibro();
                            break;
                        case 3:
                            objLibro.devolverLibro();
                            break;
                        case 4:
                            objLibro.printarLibrosPrestados();
                            break;
                        case 5:
                            objLibro.printarLibros();
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nLa opcion seleccionada no existe. Vuelva a elegir\n");
                    optiOn = mostrarMenu();

                    while (optiOn < 1 || optiOn > 6)
                    {
                        Console.WriteLine("\nLa opcion seleccionada no existe. Vuelva a elegir\n");
                        optiOn = mostrarMenu();
                    }
                }
            } while (optiOn > 0 && optiOn < 7);

            
        }
    }
}
