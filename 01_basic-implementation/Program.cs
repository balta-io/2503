
var textBox = new TextBox();
var checkBox = new CheckBox();
var button = new Button();

var mediator = new DialogMediator
{
    TextBox = textBox,
    CheckBox = checkBox,
    Button = button
};

textBox.SetMediator(mediator);
checkBox.SetMediator(mediator);
button.SetMediator(mediator);

// Interações do usuário
button.Click();              // -> Desabilitado
textBox.Input("João");       // -> Ainda desabilitado
checkBox.Toggle();           // -> Habilitado
button.Click();              // -> Clique processado!
checkBox.Toggle();           // -> Desabilitado
button.Click();              // -> Desabilitado

public interface IMediator
{
    void Notify(object sender, string ev);
}

// Classe base dos componentes
public  class Component(IMediator Mediator)
{
    
}

// Componente: TextBox
public class TextBox : Component
{
    public string Text { get; private set; } = string.Empty;

    public void Input(string value)
    {
        Text = value;
        Console.WriteLine($"[TextBox] Texto alterado para: \"{Text}\"");
        Mediator.Notify(this, "TextChanged");
    }
}

// Componente: CheckBox
public class CheckBox : Component
{
    public bool IsChecked { get; private set; }

    public void Toggle()
    {
        IsChecked = !IsChecked;
        Console.WriteLine($"[CheckBox] Marcado: {IsChecked}");
        _mediator.Notify(this, "CheckedChanged");
    }
}

// Componente: Button
public class Button : Component
{
    public bool IsEnabled { get; set; }

    public void Click()
    {
        if (IsEnabled)
            Console.WriteLine("[Button] Clique processado!");
        else
            Console.WriteLine("[Button] O botão está desabilitado.");
    }
}

// Mediator concreto
public class DialogMediator : IMediator
{
    public TextBox TextBox { get; set; }
    public CheckBox CheckBox { get; set; }
    public Button Button { get; set; }

    public void Notify(object sender, string ev)
    {
        if (ev == "TextChanged" || ev == "CheckedChanged")
        {
            bool enableButton = !string.IsNullOrWhiteSpace(TextBox.Text) && CheckBox.IsChecked;
            Button.IsEnabled = enableButton;
            Console.WriteLine($"[Mediator] Botão {(enableButton ? "habilitado" : "desabilitado")}");
        }
    }
}