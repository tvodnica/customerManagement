using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using WebForms.Models;

namespace WebForms
{
    public static class Repo
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public static bool Login(string username, string password)
        {
            int i = int.Parse(SqlHelper.ExecuteScalar(cs, "Login", username, password).ToString());

            if (i==0) return false;
            else return true;
        }

        public static bool Register(string username, string password)
        {
            bool userAlreadyExists;
            int i = int.Parse(SqlHelper.ExecuteScalar(cs, "Register", username, password).ToString());
            if (i == 0) userAlreadyExists = false;
            else if (i == 1) userAlreadyExists = true;
            else throw new Exception("Error while trying to register new user.");
            return userAlreadyExists;
        }

        public static IEnumerable<Drzava> GetDrzave()
        {
            DataTable table = SqlHelper.ExecuteDataset(cs, "GetDrzave").Tables[0];

            foreach (DataRow row in table.Rows)
            {
                yield return new Drzava()
                {
                    IDDrzava = int.Parse(row["IDDrzava"].ToString()),
                    Naziv = row["Naziv"].ToString()
                };
            }
        }

        public static IEnumerable<Grad> GetGradoviFromDrzava(int drzavaID)
        {
            DataTable table = SqlHelper.ExecuteDataset(cs, "GetGradoviFromDrzava", drzavaID).Tables[0];

            foreach (DataRow row in table.Rows)
            {
                yield return new Grad()
                {
                    IDGrad = int.Parse(row["IDGrad"].ToString()),
                    DrzavaID = int.Parse(row["DrzavaID"].ToString()),
                    Naziv = row["Naziv"].ToString()
                };
            }
        }
    }
}