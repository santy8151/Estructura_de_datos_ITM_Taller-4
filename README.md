# Expression Evaluator — Taller 4 (Stacks / Pilas)

> **Course:** Estructura de Datos — ITM  
> **Topic:** Stacks applied to infix-to-postfix expression evaluation (Shunting-yard algorithm)

[![Deploy with Vercel](https://vercel.com/button)](https://vercel.com/new/clone?repository-url=https://github.com/santy8151/Estructura_de_datos_ITM_Taller-4)

## Live Demo

🌐 **[Open the calculator on Vercel →](https://estructura-de-datos-itm-taller-4.vercel.app)**

---

## Architecture

```
ExpressionEvaluator (solution)
├── Backend/                  ← Class library — pure logic, no UI
│   └── ExpressionEvaluator.cs  (Shunting-yard + postfix evaluation)
├── Frontend.Console/         ← Console runner (4 sample expressions)
├── Frontend.Windows/         ← WinForms calculator (desktop)
└── Frontend.Web/             ← Blazor WebAssembly calculator (browser / Vercel)
```

The `Backend` project is a plain .NET class library shared by all three frontends.  
`ExpressionEvaluator.Evalute(string infix)` converts an infix expression to postfix using a **stack**, then evaluates it — no `Eval` or regex tricks.

---

## Supported operators

| Symbol | Operation     | Priority |
|--------|--------------|----------|
| `^`    | Exponent      | highest  |
| `*`    | Multiply      | medium   |
| `/`    | Divide        | medium   |
| `+`    | Add           | low      |
| `-`    | Subtract      | low      |
| `()`   | Grouping      | —        |

---

## Build & Run

**Requirements:** [.NET 10 SDK](https://dotnet.microsoft.com/download)

```bash
# Build all projects from the repo root
dotnet build ExpressionEvaluator.slnx

# Run the console frontend (shows 4 sample expressions)
dotnet run --project Frontend.Console

# Run the Blazor web frontend locally
dotnet run --project Frontend.Web

# Run the WinForms desktop frontend (Windows only)
dotnet run --project Frontend.Windows
```

### Console output

```
Infix = 4*5/(4+6),          Result = 2.00000
Infix = 4*(5+6-(8/2^3)-7)-1, Result = 11.00000
Infix = 4*7^(1/3)*7*((1+9)/3*7^4), Result = 428,675.12518
Infix = 144^(1/2),           Result = 12.00000
```

---

## Deploy to Vercel

Vercel builds the Blazor WebAssembly project and serves the static output.

```bash
# Install Vercel CLI and deploy
npm i -g vercel
vercel
```

The `vercel.json` at the root handles the build command and SPA routing fallback.

---

## Key Data Structures used

- **`Stack<char>`** — operator stack in the Shunting-yard algorithm (`ToPostfix`)
- **`Stack<double>`** — operand stack during postfix evaluation (`EvalutePostfix`)
- **`List<string>`** — ordered token list (numbers and operators)
