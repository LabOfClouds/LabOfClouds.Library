using System.Linq;
using System.Text.RegularExpressions;

namespace LabOfClouds.Library.Extenders
{
    public static class StringExtender
    {
        public static string RemoveSpecialCharacters(this string str)
        {
            /** Troca os caracteres acentuados por não acentuados **/
            string[] acentos = { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û" };
            string[] semAcento = { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };
            for (int i = 0; i < acentos.Length; i++)
            {
                str = str.Replace(acentos[i], semAcento[i]);
            }
            /** Troca os caracteres especiais da string por "" **/
            string[] caracteresEspeciais = { ".", "\\.", ",", "-", ":", ";", "?", "!", "@", "#", "$", "%", "&", "*", "\\(", "\\)", "ª", "\\|", "\\\\", "°", "[", "]", "/", "\"", "'" };

            str = caracteresEspeciais.Aggregate(str, (current, t) => current.Replace(t, ""));

            /** Troca os espaços no início por "" **/
            str = str.Replace("^\\s+", "");
            /** Troca os espaços no início por "" **/
            str = str.Replace("\\s+$", "");
            /** Troca os espaços duplicados, tabulações e etc por  " " **/
            str = str.Replace("\\s+", " ");
            return str;
        }

        public static string Capitalize(this string str)
        {
            return str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
        }

        public static string RemoveHtmlTags(this string str)
        {
            str = Regex.Replace(str, "<.*?>", string.Empty);
            return str;
        }
    }
}