namespace TeaGames.SolarSystem.UI
{
    public abstract class TrainingTipPanel : Panel
    {
        public event System.Action<TrainingTipPanel> Completed;

        protected void Complete()
        {
            Completed.Invoke(this);
        }
    }
}
