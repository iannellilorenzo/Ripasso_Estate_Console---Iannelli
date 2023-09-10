using IannelliFunzioni;

class Program
{
    static void Main(string[] args)
    {
        string file1 = Iannelli.file1;
        string file2 = Iannelli.file2;

        string zona, attuazione, data, tipoSosta, ricerca;

        if (File.Exists(file2))
        {
            Console.WriteLine("File presente.");
            SystemWait();
        }
        else
        {
            Console.WriteLine("File non presente. Caricare un file in ../bin/debug/net6.0.");
            SystemWait();
            Environment.Exit(0);
        }

        int azioneExe = 1;

        Iannelli.Azione1();
        Iannelli.Azione4();

        do
        {
            Console.Clear();

            Console.WriteLine("Funzionalità disponibili: ");
            Console.WriteLine(" 2 - Conta campi\n 3 - Lunghezza massima record\n31 - Lunghezza massima campi\n 5 - Aggiunta record in coda\n 6 - Visualli tre campi\n 7 - Ricerca per ID\n 8 - Modifica record\n 9 - Cancellazione logica\n 0 - Uscita");
            Console.Write("Inserire il numero corrispondente alla funzionalità desiderata: ");

            try
            {
                azioneExe = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("È consentito un input di solo numeri.");
                Environment.Exit(0);
            }

            switch (azioneExe)
            {
                case 2:
                    Console.WriteLine($"Il numero di campi che compone il record è: {Iannelli.Azione2()}");

                    SystemWait();
                    break;

                case 3:
                    Console.WriteLine($"La lunghezza massima dei record presenti è: {Iannelli.Azione3()}");

                    SystemWait();
                    break;

                case 31:
                    string lungs = "";

                    for (int i = 0; i < Iannelli.Azione3Avanzato().Length; i++)
                    {
                        lungs += Iannelli.Azione3Avanzato()[i] + "\n";
                    }

                    Console.WriteLine($"La lunghezza massima di ogni campo è: \n{lungs}");

                    SystemWait();
                    break;

                case 5:
                    Console.Write("Nome zona: ");
                    zona = Console.ReadLine();

                    Console.Write("Attuazione: ");
                    attuazione = Console.ReadLine();

                    Console.Write("Data (Anno): ");
                    data = Console.ReadLine();

                    Console.Write("Tipo sosta: ");
                    tipoSosta = Console.ReadLine();

                    bool azione5 = Iannelli.Azione5(zona, attuazione, data, tipoSosta);

                    if (azione5)
                    {
                        Console.WriteLine("Azione eseguita correttamente.");
                    }
                    else
                    {
                        Console.WriteLine("Compilare i campi correttamente.");
                    }

                    SystemWait();
                    break;

                case 6:
                    for (int i = 0; i < Iannelli.Azione6().Length; i++)
                    {
                        Console.WriteLine(Iannelli.Azione6()[i]);
                    }

                    SystemWait();
                    break;

                case 7:
                    Console.Write("Inserire l'ID di ricerca: ");
                    ricerca = Console.ReadLine();

                    if (Iannelli.Azione7(ricerca) == -2)
                    {
                        Console.WriteLine("Compilare correttamente i campi.");
                    }
                    else if (Iannelli.Azione7(ricerca) == -1)
                    {
                        Console.WriteLine("Elemento corrispondente all'ID inserito inesistente.");
                    }
                    else
                    {
                        Console.WriteLine($"Elemento corrispondente trovato alla riga: {Iannelli.Azione7(ricerca)}");
                    }

                    SystemWait();
                    break;

                case 8:
                    Console.Write("Nome zona: ");
                    zona = Console.ReadLine();

                    Console.Write("Attuazione: ");
                    attuazione = Console.ReadLine();

                    Console.Write("Data (Anno): ");
                    data = Console.ReadLine();

                    Console.Write("Tipo sosta: ");
                    tipoSosta = Console.ReadLine();

                    Console.Write("Ricerca: ");
                    ricerca = Console.ReadLine()

                    if (Iannelli.Azione8(zona, attuazione, data, tipoSosta, ricerca) == -2)
                    {
                        Console.WriteLine("Compilare correttamente i campi");
                    }
                    else if (Iannelli.Azione8(zona, attuazione, data, tipoSosta, ricerca) == -1)
                    {
                        Console.WriteLine("Elemento corrispondente all'ID inserito inesistente.");
                    }
                    else
                    {
                        Console.WriteLine("Azione eseguita correttamente");
                    }

                    SystemWait();
                    break;

                case 9:
                    Console.Write("Ricerca: ");
                    ricerca = Console.ReadLine();

                    Iannelli.Azione9(ricerca);

                    Console.WriteLine("Azione eseguita correttamente");

                    SystemWait();
                    break;

            }
        } while (azioneExe != 0);
    }

    static void SystemWait()
    {
        Console.Write("Premere un tasto per continuare...");
        Console.ReadKey();
    }
}