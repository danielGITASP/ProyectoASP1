﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using CinesAquiMismoWeb.DataSet1TableAdapters;

namespace CinesAquiMismoWeb
{
    public partial class ContraOlvidada : System.Web.UI.Page
    {

        static UsuariosTableAdapter usuariosAdapter = new UsuariosTableAdapter();
        static DataSet1.UsuariosDataTable usuariosTabla = new DataSet1.UsuariosDataTable();


        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;


            MailMessage mm = new MailMessage("daniel-boom@hotmail.es", txtEmail.Text);
            mm.Subject = "Tu contraseña";
            mm.Body = "Halo halo";
            mm.IsBodyHtml = true;
            mm.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            NetworkCredential nc = new NetworkCredential("danielbum96@gmail.com", "notengoniidea");
            nc.UserName = "danielbum96@gmail.com";
            nc.Password = "notengoniidea";

            smtp.Credentials = nc;
            smtp.Port = 587;

            usuariosTabla = usuariosAdapter.GetData();
            string emailT = txtEmail.Text;
            string emailU;
            bool mandado = false;

            for (int i = 0; i < usuariosTabla.Count; i++)
            {
                emailU = usuariosTabla[i].Email;

                if (emailT == emailU)
                {
                    //string nuevaContra = GeneraContraseña();
                    //CambiaContraseña(usuariosTabla[i].idUsuario, nuevaContra);
                    mandado = true;
                    mm.Body = "Ve a este link: <a href=" + "http://cinesaquimismoasp.azurewebsites.net/ContraCambioLink.aspx?usuID=" + usuariosTabla[i].idUsuario + ">Cambiar Contraseña</a>";
                    smtp.Send(mm);
                    lblCorreo.ForeColor = System.Drawing.Color.Green;
                    lblCorreo.Text = "Se ha enviado el correo";
                    lblCorreo.Visible = true;
                }
            }

            if (!mandado)
            {
                lblCorreo.ForeColor = System.Drawing.Color.Red;
                lblCorreo.Text = "No se encuentra ese correo";
                lblCorreo.Visible = true;
            }

        }


        //public string GeneraContraseña()
        //{
        //    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        //    var stringChars = new char[8];
        //    var random = new Random();

        //    for (int j = 0; j < stringChars.Length; j++)
        //    {
        //        stringChars[j] = chars[random.Next(chars.Length)];
        //    }

        //    var finalString = new String(stringChars);
        //    return finalString;
        //}

        //public void CambiaContraseña(int id, string ncontra)
        //{
        //    DataSet1.UsuariosRow regUsuario = usuariosTabla.FindByidUsuario(id);
        //    regUsuario.Password = ncontra;

        //    usuariosAdapter.Update(regUsuario);
        //    usuariosTabla.AcceptChanges();

        //}


    }
}