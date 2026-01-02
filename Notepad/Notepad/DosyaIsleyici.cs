using System.IO;

public static class DosyaIsleyici
{
    public static string DosyaOku(string dosyaYolu)
    {
        if (!File.Exists(dosyaYolu))
        {
            throw new FileNotFoundException("Dosya bulunamadı.");
        }
        return File.ReadAllText(dosyaYolu);
    }

    public static void DosyaYaz(string dosyaYolu, string icerik)
    {
        File.WriteAllText(dosyaYolu, icerik);
    }
}