using Microsoft.Win32;
using System;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Mail;

namespace LerXML.Classes
{
    class Funcoes
    {


        public static DateTime ConvertJulianToDateTime(double julianDate)
        {
            var dataRef = new DateTime(1900, 1, 1);
            return dataRef.AddDays(julianDate - 2);
        }

        public static string RetiraAcentos(string valor)
        {
            var acentos = new[] { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û" };
            var semAcento = new[] { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };
            for (int i = 0; i < acentos.Length; i++)
            {
                valor = valor.Replace(acentos[i], semAcento[i]);
            }
            string[] caracteresEspeciais = { "\\.", ",", "-", ":", "\\(", "\\)", "ª", "\\|", "\\\\", "°" };
            valor = caracteresEspeciais.Aggregate(valor, (current, t) => current.Replace(t, ""));
            valor = valor.Replace("^\\s+", "");
            valor = valor.Replace("\\s+$", "");
            valor = valor.Replace("\\s+", " ");
            return valor;
        }

        public static void EnviarEmail1(string destinatarioNome, string destinatarioEmail, string assunto, string corpoEmail)
        {
            var cliente = new SmtpClient();
            cliente.Host = "smtp.gmail.com";
            cliente.Port = 465;
            cliente.EnableSsl = true;
            cliente.UseDefaultCredentials = false;
            var credenciais = new NetworkCredential("renatolsouza@gmail.com", "pedroefelipe");
            cliente.Credentials = credenciais;

            var remetente = new MailAddress("renatolsouza@gmail.com", "Oficio Informática - TI (Programação)");
            var destinatario = new MailAddress(destinatarioEmail, destinatarioNome);
            var mensagem = new MailMessage(remetente, destinatario) { Body = corpoEmail, Subject = assunto, IsBodyHtml = true };


            cliente.Send(mensagem);
        }

        public static void EnviarEmail(string destinatarioNome, string destinatarioEmail, string assunto, string corpoEmail)
        {
            var cliente = new SmtpClient("smtp.gmail.com", 587) { EnableSsl = true };
            var remetente = new MailAddress("oficiotecnologia@gmail.com", "Oficio Tecnologia - TI (Programação)");
            var destinatario = new MailAddress(destinatarioEmail, destinatarioNome);
            var mensagem = new MailMessage(remetente, destinatario) { Body = corpoEmail, Subject = assunto, IsBodyHtml = true };
            var credenciais = new NetworkCredential("oficiotecnologia@gmail.com", "@cpdrede12");
            cliente.Credentials = credenciais;
            cliente.Send(mensagem);
        }

        public static string removeFormatacao(string texto)
        {
            string txt = "";
            txt = texto.Replace(".", "");
            txt = txt.Replace("-", "");
            txt = txt.Replace("/", "");
            txt = txt.Replace("(", "");
            txt = txt.Replace(")", "");
            txt = txt.Replace(" ", "");
            return txt;
        }

        public static string tiraponto(string texto)
        {
            string txt = "";
            txt = texto.Replace(".", ",");

            return txt;
        }

        public static int FaltaQuantofinAno()
        {
            DateTime agora = DateTime.Now;
            var ano = agora.Year;

            DateTime inicio = Convert.ToDateTime(ano + ", 12, 31");


            DateTime data_inicial = agora;
            DateTime data_final = inicio;

            // obtém a diferença
            TimeSpan dif = data_final.Subtract(data_inicial);

            // exibe o resultado
            var quatos = (dif.Days / 30);

            return quatos;
        }

        public static string TirarAcento(string palavra)
        {
            string palavraSemAcento = "";
            string caracterComAcento = "áàãâäéèêëíìîïóòõôöúùûüçÁÀÃÂÄÉÈÊËÍÌÎÏÓÒÕÖÔÚÙÛÜÇ";
            string caracterSemAcento = "aaaaaeeeeiiiiooooouuuucAAAAAEEEEIIIIOOOOOUUUUC";

            for (int i = 0; i < palavra.Length; i++)
            {
                if (caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1))) >= 0)
                {
                    int car = caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1)));
                    palavraSemAcento += caracterSemAcento.Substring(car, 1);
                }
                else
                {
                    palavraSemAcento += palavra.Substring(i, 1);
                }
            }

            return palavraSemAcento;
        }


        public static string BuscarDiscoLogico(string strDriveLetter)
        {
            if (strDriveLetter == "" || strDriveLetter == null) strDriveLetter = "C";
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + strDriveLetter + ":\"");
            disk.Get();
            return disk["VolumeSerialNumber"].ToString();
        }

        public static string Criptografar(string txtNormal)
        {
            string texto = txtNormal;

            string key = "RenatoLeandro"; //Está chave você mesmo é quem escolhe.

            Criptografia crip = new Criptografia(CryptProvider.DES);

            crip.Key = key;

            return crip.Encrypt(texto);

        }

        public static string Decriptar(string txtCriptografado)
        {

            string texto = txtCriptografado;


            //Está chave tem que ser a mesma que a do texto Encriptado.

            string key = "RenatoLeandro";


            Criptografia crip = new Criptografia(CryptProvider.DES);

            crip.Key = key;


            return crip.Decrypt(texto);

        }

        public static void GravaRegistro(string chave)
        {
            try
            {
                // cria uma referêcnia para a chave de registro Software
                RegistryKey rk = Registry.CurrentUser.CreateSubKey("Chave");
                // cria um Subchave como o nome GravaRegistro
                rk = rk.CreateSubKey("Registro");
                // grava o caminho na SubChave GravaRegistro
                rk.SetValue("Chave", chave);
                // fecha a Chave de Restistro registro
                rk.Close();
                //MessageBox.Show("Caminho gravado com Sucesso!");

            }
            catch (Exception erro)
            {
                //MessageBox.Show("Erro no gravação do Registro: " + erro.Message);
            }
        }

        public static string LerRegistro()
        {
            var registro = "";
            try
            {
                // cria uma referêcnia para a chave de registro Software
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("Chave", true);
                // realiza a leitura do registro
                registro = rk.OpenSubKey("Registro", true).GetValue("Chave").ToString();
            }
            catch (Exception erro)
            {
                //MessageBox.Show("Erro na leitura do Registro: " + erro.Message);
            }
            return registro;

        }

        public static string BuscaChave()
        {
            var retorno = "";
            var registro = LerRegistro();

            if (registro == "")
            {
                //retorno = "N";
            }
            else
            {
                retorno = registro;
            }

            return retorno;
        }

        public static bool ValidaRegistro()
        {
            bool retorno;
            var registro = LerRegistro();
            var numHD1 = "";
            var data1 = "";

            try
            {

                if (registro != "")
                {

                    registro = Decriptar(registro);

                    int caract = registro.Length;
                    caract = caract - 10;
                    //menos 10
                    numHD1 = registro.Substring(0, caract);
                    data1 = registro.Substring(caract, 10);

                    DateTime date = DateTime.Now;


                    var numHD2 = BuscarDiscoLogico("");
                    var data2 = date.ToString("dd/MM/yyyy");

                    if (numHD1 == numHD2)
                    {
                        // se dt1 for maior que dt2 -> dt1 é a data final de uso do prog 
                        var dt1 = Convert.ToDateTime(data1);
                        var dt2 = Convert.ToDateTime(data2);

                        if (dt1 > dt2)
                        {
                            retorno = true;
                        }
                        else
                        {
                            retorno = false;
                        }
                    }
                    else
                    {
                        retorno = false;
                    }

                }
                else
                {
                    retorno = false;
                }
            }
            catch
            {
                retorno = false;
            }
            return retorno;
        }


    }
}
