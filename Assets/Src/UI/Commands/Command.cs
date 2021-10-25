namespace Asteroids.UI.Commands
{
    public abstract class Command
    {
        public bool Succeeded  { get; private set; }
        
        public virtual void Execute()
        {
            Succeeded = true;
        }

        public virtual void Undo()
        {
            Succeeded = false;
        }
    }
}