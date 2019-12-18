namespace Profilrechner
{
    public class CatiaSpeichern
    {
        private int speichernI;

        public CatiaSpeichern(int speichernI)
        {
            CatiaConnection ccS = new CatiaConnection();

            if (speichernI == 1)
            {
                ccS.Save();
            }
            
        }
    }
}