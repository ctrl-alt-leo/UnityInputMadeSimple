# Unity Input Made Simple

A ideia é tornar a utilização do Input System da Unity parecido com a versão antiga, sem complicações e sem comprometer performance.

# Funcionalidades

    Acesso Global: Sem necessidade de referências manuais ou GetComponent.

    Suavização: Métodos integrados para movimentos de câmera e personagens fluidos.
    
    Performance: Cache de dicionários e zero alocação de lixo (GC) no loop principal.

# Instalação via Git (UPM)

Para instalar este sistema em seu projeto Unity usando o Package Manager:

    1. No Unity, abra a janela Window > Package Manager.
    2. Clique no botão + (mais) no canto superior esquerdo.
    3. Selecione Add package from git URL....
    4. Cole a URL deste repositório:
       https://github.com/ctrl-alt-leo/UnityInputMadeSimple.git
    5. Clique em Add.

* Certifique-se de ter o Git instalado em sua máquina para que o Unity possa clonar o pacote.

# Como Usar

    1. Crie um GameObject chamado InputManager na sua primeira cena.
    2. Arraste seu InputActionAsset para o campo Input Asset.
    3. Selecione o Default Action Map no dropdown.

# Exemplos de Código

    // 1. Botões Simples
    if (InputManager.GetButtonDown("Jump")) {
    }

    if (InputManager.GetButtonUp("Jump")) {
    }

    if (InputManager.GetButton("Sprint")) {
    }

    // 2. Vetores Digitais
    Vector2 move = InputManager.GetVector2("Move");
    Vector2 look = InputManager.GetVector2("Look");

    // 3. Vetores Suavizados
    Vector3 move = InputManager.GetVector2("Move", 0.1f);
    Vector2 look = InputManager.GetVector2("Look", 0.1f);

    // 4. Troca de Contexto (Mapa de Ação)
    InputManager.SwitchActionMap("Driving");

# Licença

Distribuído sob a Licença MIT. Veja LICENSE.md para mais informações.
