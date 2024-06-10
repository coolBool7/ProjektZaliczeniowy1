using System;
using System.Collections.Generic;
using System.Text.Json;
using PZK;
using PZK.LibraryApp;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MenadzerPersistencji menadzerPersistencji = new MenadzerPersistencji("biblioteka.json");
            Biblioteka biblioteka = menadzerPersistencji.WczytajBiblioteke();
            bool dzialanie = true;

            while (dzialanie)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Wczytaj bibliotekę");
                Console.WriteLine("2. Zapisz bibliotekę");
                Console.WriteLine("3. Dodaj książkę");
                Console.WriteLine("4. Dodaj e-book");
                Console.WriteLine("5. Dodaj audiobook");
                Console.WriteLine("6. Wyszukaj książki");
                Console.WriteLine("7. Wyświetl wszystkie książki");
                Console.WriteLine("8. Wyświetl e-booki");
                Console.WriteLine("9. Wyświetl audiobooki");
                Console.WriteLine("10. Usuń książkę");
                Console.WriteLine("0. Wyjdź");
                Console.Write("Wybierz opcję: ");

                string wybor = Console.ReadLine();
                switch (wybor)
                {
                    case "1":
                        biblioteka = menadzerPersistencji.WczytajBiblioteke();
                        Console.WriteLine("Biblioteka została wczytana.");
                        break;
                    case "2":
                        menadzerPersistencji.ZapiszBiblioteke(biblioteka);
                        Console.WriteLine("Biblioteka została zapisana.");
                        break;
                    case "3":
                        DodajKsiazke(biblioteka);
                        break;
                    case "4":
                        DodajEbook(biblioteka);
                        break;
                    case "5":
                        DodajAudiobook(biblioteka);
                        break;
                    case "6":
                        WyszukajKsiazki(biblioteka);
                        break;
                    case "7":
                        WyswietlKsiazki(biblioteka);
                        break;
                    case "8":
                        WyswietlEbooki(biblioteka);
                        break;
                    case "9":
                        WyswietlAudiobooki(biblioteka);
                        break;
                    case "10":
                        UsunKsiazke(biblioteka);
                        break;
                    case "0":
                        dzialanie = false;
                        Console.WriteLine("Zamknięcie programu...");
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                        break;
                }
            }
        }

        static void DodajKsiazke(Biblioteka biblioteka)
        {
            try
            {
                Console.Write("Podaj tytuł: ");
                string tytul = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tytul))
                {
                    throw new ArgumentException("Tytuł nie może być pusty.");
                }

                Console.Write("Podaj autora: ");
                string autor = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(autor))
                {
                    throw new ArgumentException("Autor nie może być pusty.");
                }

                Console.Write("Podaj gatunek: ");
                string gatunek = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(gatunek))
                {
                    throw new ArgumentException("Gatunek nie może być pusty.");
                }

                Console.Write("Podaj rok: ");
                if (!int.TryParse(Console.ReadLine(), out int rok) || rok <= 0)
                {
                    throw new ArgumentException("Rok musi być dodatnią liczbą całkowitą.");
                }

                Ksiazka ksiazka = new Ksiazka(tytul, autor, gatunek, rok);
                biblioteka.DodajKsiazke(ksiazka);
                Console.WriteLine("Dodano książkę.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd: " + ex.Message);
            }
        }

        static void DodajEbook(Biblioteka biblioteka)
        {
            try
            {
                Console.Write("Podaj tytuł: ");
                string tytul = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tytul))
                {
                    throw new ArgumentException("Tytuł nie może być pusty.");
                }

                Console.Write("Podaj autora: ");
                string autor = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(autor))
                {
                    throw new ArgumentException("Autor nie może być pusty.");
                }

                Console.Write("Podaj gatunek: ");
                string gatunek = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(gatunek))
                {
                    throw new ArgumentException("Gatunek nie może być pusty.");
                }

                Console.Write("Podaj rok: ");
                if (!int.TryParse(Console.ReadLine(), out int rok) || rok <= 0)
                {
                    throw new ArgumentException("Rok musi być dodatnią liczbą całkowitą.");
                }

                Console.Write("Podaj rozmiar pliku (w MB): ");
                if (!double.TryParse(Console.ReadLine(), out double rozmiarPliku) || rozmiarPliku <= 0)
                {
                    throw new ArgumentException("Rozmiar pliku musi być dodatnią liczbą zmiennoprzecinkową.");
                }

                Ebook ebook = new Ebook(tytul, autor, gatunek, rok, rozmiarPliku);
                biblioteka.DodajKsiazke(ebook);
                Console.WriteLine("Dodano e-book.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd: " + ex.Message);
            }
        }

        static void DodajAudiobook(Biblioteka biblioteka)
        {
            try
            {
                Console.Write("Podaj tytuł: ");
                string tytul = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tytul))
                {
                    throw new ArgumentException("Tytuł nie może być pusty.");
                }

                Console.Write("Podaj autora: ");
                string autor = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(autor))
                {
                    throw new ArgumentException("Autor nie może być pusty.");
                }

                Console.Write("Podaj gatunek: ");
                string gatunek = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(gatunek))
                {
                    throw new ArgumentException("Gatunek nie może być pusty.");
                }

                Console.Write("Podaj rok: ");
                if (!int.TryParse(Console.ReadLine(), out int rok) || rok <= 0)
                {
                    throw new ArgumentException("Rok musi być dodatnią liczbą całkowitą.");
                }

                Console.Write("Podaj czas trwania (w godzinach): ");
                if (!double.TryParse(Console.ReadLine(), out double czasTrwania) || czasTrwania <= 0)
                {
                    throw new ArgumentException("Czas trwania musi być dodatnią liczbą zmiennoprzecinkową.");
                }

                Audiobook audiobook = new Audiobook(tytul, autor, gatunek, rok, czasTrwania);
                biblioteka.DodajKsiazke(audiobook);
                Console.WriteLine("Dodano audiobook.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd: " + ex.Message);
            }
        }

        static void WyszukajKsiazki(Biblioteka biblioteka)
        {
            try
            {
                Console.Write("Podaj frazę do wyszukania: ");
                string fraza = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(fraza))
                {
                    throw new ArgumentException("Fraza do wyszukania nie może być pusta.");
                }

                Console.Write("Wyszukiwanie po (tytul/autor/gatunek): ");
                string poCzym = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(poCzym))
                {
                    throw new ArgumentException("Kryterium wyszukiwania nie może być puste.");
                }

                List<Ksiazka> wyniki = biblioteka.WyszukajKsiazki(fraza, poCzym);
                if (wyniki.Count > 0)
                {
                    Console.WriteLine("Znaleziono książki:");
                    foreach (var ksiazka in wyniki)
                    {
                        Console.WriteLine(ksiazka);
                    }
                }
                else
                {
                    Console.WriteLine("Brak wyników.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd: " + ex.Message);
            }
        }

        static void WyswietlKsiazki(Biblioteka biblioteka)
        {
            List<Ksiazka> ksiazki = biblioteka.PobierzKsiazki();
            if (ksiazki.Count > 0)
            {
                Console.WriteLine("Książki w bibliotece:");
                foreach (var ksiazka in ksiazki)
                {
                    Console.WriteLine(ksiazka);
                }
            }
            else
            {
                Console.WriteLine("Biblioteka jest pusta.");
            }
        }

        static void WyswietlEbooki(Biblioteka biblioteka)
        {
            List<Ksiazka> ebooki = biblioteka.PobierzKsiazkiPoTypie<Ebook>();
            if (ebooki.Count > 0)
            {
                Console.WriteLine("E-booki w bibliotece:");
                foreach (var ebook in ebooki)
                {
                    Console.WriteLine(ebook);
                }
            }
            else
            {
                Console.WriteLine("Brak e-booków w bibliotece.");
            }
        }

        static void WyswietlAudiobooki(Biblioteka biblioteka)
        {
            List<Ksiazka> audiobooki = biblioteka.PobierzKsiazkiPoTypie<Audiobook>();
            if (audiobooki.Count > 0)
            {
                Console.WriteLine("Audiobooki w bibliotece:");
                foreach (var audiobook in audiobooki)
                {
                    Console.WriteLine(audiobook);
                }
            }
            else
            {
                Console.WriteLine("Brak audiobooków w bibliotece.");
            }
        }

        static void UsunKsiazke(Biblioteka biblioteka)
        {
            try
            {
                Console.Write("Podaj tytuł książki do usunięcia: ");
                string tytul = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tytul))
                {
                    throw new ArgumentException("Tytuł nie może być pusty.");
                }

                bool usunieto = biblioteka.UsunKsiazkePoTytule(tytul);
                if (usunieto)
                {
                    Console.WriteLine($"Książka '{tytul}' została usunięta.");
                }
                else
                {
                    Console.WriteLine($"Nie znaleziono książki o tytule '{tytul}'.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd: " + ex.Message);
            }
        }
    }
}