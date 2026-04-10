Unity Input Made Simple

Este pacote abstrai a complexidade do New Input System da Unity, oferecendo uma interface estática de alto desempenho, semelhante ao sistema antigo, mas com recursos modernos como suavização de input e suporte nativo a múltiplos dispositivos.

🚀 Funcionalidades

    Acesso Global: Sem necessidade de referências manuais ou GetComponent.

    Suavização: Métodos integrados para movimentos de câmera e personagens fluidos.
    
    Performance: Cache de dicionários e zero alocação de lixo (GC) no loop principal.

📦 Instalação via Git (UPM)

Para instalar este sistema em seu projeto Unity usando o Package Manager:

    No Unity, abra a janela Window > Package Manager.

    Clique no botão + (mais) no canto superior esquerdo.

    Selecione Add package from git URL....

    Cole a URL deste repositório:
    https://github.com/seu-usuario/nome-do-repositorio.git

    Clique em Add.

Certifique-se de ter o Git instalado em sua máquina para que o Unity possa clonar o pacote.

📖 Como Usar
Configuração Inicial

    Crie um GameObject chamado InputManager na sua primeira cena.

    Arraste seu InputActionAsset para o campo Input Asset.

    Selecione o Default Action Map no dropdown.

Exemplos de Código
C#

// 1. Botões Simples
if (InputManager.GetButtonDown("Jump")) {
    DoJump();
}

// 2. Vetores Digitais (WASD / Stick)
Vector2 move = InputManager.GetVector2("Move");

// 3. Vetores Suavizados (Ideal para Câmera FPS)
// O valor 0.05f é o SmoothTime
Vector2 look = InputManager.GetVector2("Look", 0.05f);

// 4. Troca de Contexto (Mapa de Ação)
InputManager.SwitchActionMap("Driving");

⚖️ Licença

Distribuído sob a Licença MIT. Veja LICENSE.md para mais informações.
