
public interface IButton {
    void Render();
    void OnClick(Action actiont);
}

public class WindowButton : IButton {
    public void Render() {
          Console.WriteLine("Representa un botón en estilo Windows.");
    }

    public void OnClick(Action actiont) {
          Console.WriteLine("Representa un botón en estilo Windows.");
    }
}

public class HTMLButton  : IButton {
    public void Render() {
          Console.WriteLine("Devuelve una representación HTML de un botón.");
    }

    public void OnClick(Action actiont) {
          Console.WriteLine("Representa un botón en estilo Windows.");
    }
}

public class Dialog {

    public abstract  IButton CreateButton();

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

    var OS = "Windows";
    this.Initialize(OS);
    dialog.Render();