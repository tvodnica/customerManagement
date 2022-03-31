using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Repo
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;


        // ------- GET  -------
        public static IEnumerable<Kupac> GetKupci()
        {
            DataTable table = SqlHelper.ExecuteDataset(cs, "GetKupci").Tables[0];
            foreach (DataRow row in table.Rows)
            {
                yield return new Kupac()
                {
                    IDKupac = int.Parse(row["IDKupac"].ToString()),
                    Ime = row["Ime"].ToString(),
                    Prezime = row["Prezime"].ToString(),
                    Telefon = row["Telefon"].ToString(),
                    Email = row["Email"].ToString(),
                    GradID = int.Parse(row["GradID"].ToString())
                };
            }
        }
        public static IEnumerable<StavkaVM> GetStavkeVM(int id)
        {
            DataTable table = SqlHelper.ExecuteDataset(cs, "GetStavkeVM", id).Tables[0];
            foreach (DataRow row in table.Rows)
            {
                yield return new StavkaVM()
                {
                    Stavka = new Stavka()
                    {
                        IDStavka = int.Parse(row["IDStavka"].ToString()),
                        Kolicina = int.Parse(row["Kolicina"].ToString()),
                        ProizvodID = int.Parse(row["ProizvodID"].ToString()),
                        CijenaPoKomadu = double.Parse(row["CijenaPoKomadu"].ToString()),
                        UkupnaCijena = double.Parse(row["UkupnaCijena"].ToString()),
                        PopustUPostocima = double.Parse(row["PopustUPostocima"].ToString()),
                        RacunID = int.Parse(row["RacunID"].ToString())
                    },
                    Kategorija = new Kategorija()
                    {
                        IDKategorija = int.Parse(row["IDKategorija"].ToString()),
                        Naziv = row["KategorijaNaziv"].ToString()
                    },
                    Potkategorija = new Potkategorija()
                    {
                        IDPotkategorija = int.Parse(row["IDPotkategorija"].ToString()),
                        KategorijaID = int.Parse(row["KategorijaID"].ToString()),
                        Naziv = row["PotkategorijaNaziv"].ToString()
                    },
                    Proizvod = new Proizvod()
                    {
                        IDProizvod = int.Parse(row["IDProizvod"].ToString()),
                        Naziv = row["ProizvodNaziv"].ToString()
                    }

                };
            }
        }
        public static IEnumerable<Racun> GetRacuni(int kupacID)
        {
            DataTable table = SqlHelper.ExecuteDataset(cs, "GetRacuni", kupacID).Tables[0];
            foreach (DataRow row in table.Rows)
            {
                yield return new Racun()
                {
                    IDRacun = int.Parse(row["IDRacun"].ToString()),
                    KomercijalistID = int.Parse(row["KomercijalistID"].ToString()),
                    KreditnaKarticaID = int.Parse(row["KreditnaKarticaID"].ToString()),
                    KupacID = int.Parse(row["KupacID"].ToString()),
                    DatumIzdavanja = DateTime.Parse(row["DatumIzdavanja"].ToString()),
                    Komentar = row["Komentar"].ToString(),
                    BrojRacuna = row["BrojRacuna"].ToString()
                };
            }
        }
        public static IEnumerable<Stavka> GetStavke(int id)
        {
            DataTable table = SqlHelper.ExecuteDataset(cs, "GetStavke", id).Tables[0];
            foreach (DataRow row in table.Rows)
            {
                yield return new Stavka()
                {
                    IDStavka = int.Parse(row["IDStavka"].ToString()),
                    Kolicina = int.Parse(row["Kolicina"].ToString()),
                    ProizvodID = int.Parse(row["ProizvodID"].ToString()),
                    CijenaPoKomadu = double.Parse(row["CijenaPoKomadu"].ToString()),
                    UkupnaCijena = double.Parse(row["UkupnaCijena"].ToString()),
                    PopustUPostocima = double.Parse(row["PopustUPostocima"].ToString()),
                    RacunID = int.Parse(row["RacunID"].ToString())
                };
            }
        }
       
        public static Potkategorija GetPotkategorija(int id)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetPotkategorija", id).Tables[0].Rows[0];
            return new Potkategorija()
            {
                IDPotkategorija = int.Parse(row["IDPotkategorija"].ToString()),
                Naziv = row["Naziv"].ToString(),
                KategorijaID = int.Parse(row["KategorijaID"].ToString())
            };
        }
        public static Proizvod GetProizvod(int id)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetProizvod", id).Tables[0].Rows[0];
            return new Proizvod()
            {
                IDProizvod = int.Parse(row["IDProizvod"].ToString()),
                Naziv = row["Naziv"].ToString(),
                Boja = row["Boja"].ToString(),
                BrojProizvoda = row["BrojProizvoda"].ToString(),
                PotkategorijaID = int.Parse(row["PotkategorijaID"].ToString()),
                MinimalnaKolicinaNaSkladistu = int.Parse(row["MinimalnaKolicinaNaSkladistu"].ToString()),
                CijenaBezPDV = double.Parse(row["CijenaBezPDV"].ToString()),
            };
        }
        public static Kategorija GetKategorija(int id)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetKategorija", id).Tables[0].Rows[0];
            return new Kategorija()
            {
                IDKategorija = int.Parse(row["IDKategorija"].ToString()),
                Naziv = row["Naziv"].ToString()
            };
        }
        public static KreditnaKartica GetKreditnaKartica(int id)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetKreditnaKartica", id).Tables[0].Rows[0];
            return new KreditnaKartica()
            {
                IDKreditnaKartica = int.Parse(row["IDKreditnaKartica"].ToString()),
                Tip = row["Tip"].ToString(),
                Broj = row["Broj"].ToString(),
                IstekGodina = int.Parse(row["IstekGodina"].ToString()),
                IstekMjesec = int.Parse(row["IstekMjesec"].ToString()),
            };
        }
        public static Komercijalist GetKomercijalist(int komercijalistID)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetKomercijalist", komercijalistID).Tables[0].Rows[0];
            return new Komercijalist()
            {
                IDKomercijalist = int.Parse(row["IDKomercijalist"].ToString()),
                Ime = row["Ime"].ToString(),
                Prezime = row["Prezime"].ToString(),
                // StalniZaposlenik = int.Parse(row["StalniZaposlenik"].ToString()) == 0 ? false : true,
            };
        }



        // ------- INSERT -------
        public static void InsertProizvod(Proizvod p)
        {
            SqlHelper.ExecuteNonQuery(cs, "InsertProizvod",
                p.PotkategorijaID,
                p.Naziv,
                p.BrojProizvoda,
                p.Boja,
                p.MinimalnaKolicinaNaSkladistu,
                p.CijenaBezPDV
                );
        }
        public static void InsertPotkategorija(Potkategorija p)
        {
            SqlHelper.ExecuteNonQuery(cs, "InsertPotkategorija",
                p.KategorijaID,
                p.Naziv
                );
        }
        public static void InsertKategorija(Kategorija k)
        {
            SqlHelper.ExecuteNonQuery(cs, "InsertKategorija",
                k.Naziv
                );
        }


        // ------- UPDATE -------
        public static void UpdateProizvod(Proizvod p)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateProizvod",
                p.IDProizvod,
                p.PotkategorijaID,
                p.Naziv,
                p.BrojProizvoda,
                p.Boja,
                p.MinimalnaKolicinaNaSkladistu,
                p.CijenaBezPDV
                );
        }
        public static void UpdateKategorija(Kategorija k)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateKategorija",
              k.IDKategorija,
              k.Naziv
              );
        }
        public static void UpdatePotkategorija(Potkategorija p)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdatePotkategorija",
             p.IDPotkategorija,
             p.KategorijaID,
             p.Naziv
             );
        }



        // ------- DELETE -------
        public static void DeleteProizvod(int id)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteProizvod", id);
        }
        public static void DeleteKategorija(int id)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteKategorija", id);
        }
        public static void DeletePotkategorija(int id)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeletePotkategorija", id);
        }
    }
}