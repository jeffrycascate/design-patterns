using static System.Net.Mime.MediaTypeNames;

public interface IButton
{
    void Render();

    void OnClick(Action actiont);
}

public class WindowsButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Representa un botón en estilo Windows.");
    }

    public void OnClick(Action actiont)
    {
        Console.WriteLine("Representa un botón en estilo Windows.");
    }
}

public class HTMLButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Devuelve una representación HTML de un botón.");
    }

    public void OnClick(Action actiont)
    {
        Console.WriteLine("Representa un botón en estilo Windows.");
    }
}

public abstract class Dialog
{
    public abstract IButton CreateButton();

    public void Render()
    {
        IButton okButton = CreateButton();
        okButton.OnClick(CloseDialog);
        okButton.Render();
    }

    private void CloseDialog()
    {
        Console.WriteLine("Cerrando diálogo.");
    }
}

public class WindowsDialog : Dialog
{
    public override IButton CreateButton()
    {
        return new WindowsButton();
    }
}

public class WebDialog : Dialog
{
    public override IButton CreateButton()
    {
        return new HTMLButton();
    }
}

public class Application
{
    private Dialog dialog;

    public void Initialize(string OS)
    {
        if (OS == "Windows")
            dialog = new WindowsDialog();
        else if (OS == "Web")
            dialog = new WebDialog();
        else
            throw new Exception("Error! Unknown operating system.");
    }

    public void Main(string OS)
    {
        this.Initialize(OS);
        dialog.Render();
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        var app = new Application();
        app.Main("Windows"); // Cambia esto según el sistema operativo
    }
}