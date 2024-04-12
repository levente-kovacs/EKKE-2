namespace Edesszajuak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Edessegbolt edessegbolt = new Edessegbolt();
            StreamReader sr = new StreamReader("edessegek.txt");
            while(!sr.EndOfStream)
            {
                string[] lineParts = sr.ReadLine().Split(';');
            }
            sr.Close();

        }
    }
}