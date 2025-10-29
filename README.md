# ZE Agentic Demo

A practical implementation of **Context Engineering** principles - demonstrating how to maximize signal and minimize noise in AI agent workflows through structured multi-agent orchestration.

> **📺 Companion Resource**: This repository accompanies the "Context Engineering" presentation by [Zachary Etier](https://www.linkedin.com/in/zach-etier-a90b4840/). See `docs/ZE_ContextEngineering_Presentation.pdf` for the full presentation.

---

## Table of Contents

- [What is Context Engineering?](#what-is-context-engineering)
- [The Lost in the Middle Problem](#the-lost-in-the-middle-problem)
- [Quick Start](#quick-start)
- [Demo Application](#demo-application)
- [The ZE Workflow](#the-ze-workflow)
- [Context Engineering in Practice](#context-engineering-in-practice)
- [Project Structure](#project-structure)
- [Best Practices](#best-practices)
- [Documentation](#documentation)
- [License](#license)

---

## What is Context Engineering?

**Context Engineering** is the practice of maximizing signal and minimizing noise by deliberately curating a stream of concise, highly relevant information for an agent, rather than allowing the agent to passively consume data on its own.

### Four Core Practices

1. **Precision Filtering** - Pass only critical, actionable data (e.g., processing errors, not all warnings)
2. **Hierarchical Summarization** - Use sub-agents to process dense documents, feed concise summaries to main agent
3. **Advanced Retrieval** - Implement dynamic search, re-rank results, query multiple sources
4. **Contextual Scaffolding** - Clear output schemas, guided problem-solving approach

---

## The "Lost in the Middle" Problem

AI agents suffer performance degradation when critical information is buried in the middle of the context window.

**The Problem:**
```
┌─────────────────────┐
│  System Instructions│  ← High Performance
│  CLAUDE.md         │
│  User Prompt       │
├─────────────────────┤
│  Task 1            │
│  Task 2            │  ← Low Performance
│  Task 3 (LOST!)    │     ("Lost in the Middle")
│  Task 4            │
├─────────────────────┤
│  Current User Ask  │  ← High Performance
│  Latest Task       │
└─────────────────────┘
```

**Our Solution:**
- ✅ **Sub-agent decomposition** - Breaking complex tasks into focused sub-tasks
- ✅ **Hierarchical summarization** - Condensing verbose outputs before presenting to main agent
- ✅ **Phased execution** - One step at a time to maintain context clarity
- ✅ **Structured workflows** - Consistent patterns that keep important information at context boundaries

---

## Quick Start

### Prerequisites

- Claude Code CLI
- .NET 9 SDK (for demo application)

### Try the Workflow

**1. Create a Ticket**
```bash
/ZE_1_Ticket ZE_Agentic_Demo.sln "Fix bug where CompletedAt is not set when task status changes to Completed"
```

**2. Research the Codebase**
```bash
/ZE_2_Research ZE_Agentic_Demo.sln thoughts/tickets/bug_completed_timestamp.md
```

**3. Create an Implementation Plan**
```bash
/ZE_3_Plan ZE_Agentic_Demo.sln thoughts/tickets/bug_completed_timestamp.md thoughts/research/2025-01-29_task_service.md
```

**4. Execute the Plan (one phase at a time)**
```bash
/ZE_4_Execute ZE_Agentic_Demo.sln thoughts/plans/fix-completed-timestamp.md
```

**5. Verify Implementation**
```bash
/ZE_5_Verify ZE_Agentic_Demo.sln thoughts/plans/fix-completed-timestamp.md
```

Each command provides structured output with the exact next command to run.

---

## Demo Application

A simple **Task Manager API** built with ASP.NET Core for demonstrating the ZE workflow.

### Running the Demo

```bash
cd src/TaskManagerApi
dotnet run
```

- **API**: http://localhost:5000
- **Swagger UI**: http://localhost:5000/swagger

### Intentional Issues (For Demo)

**Bugs to Fix:**
1. ❌ `CompletedAt` timestamp not set when status changes to Completed
2. ❌ No input validation on POST /tasks endpoint

**Features to Add:**
1. ➕ Filter tasks by status endpoint
2. ➕ Filter tasks by priority endpoint
3. ➕ Search tasks by title/description
4. ➕ Statistics/summary endpoint

See `src/TaskManagerApi/README.md` for detailed usage and examples.

---

## The ZE Workflow

A systematic, multi-agent approach to software development using Context Engineering principles.

```
┌──────────────────┐
│  /ZE_1_Ticket    │  Create structured tickets
│        ↓         │  - Interactive scope exploration
└──────────────────┘  - Extract keywords for research
         ↓
┌──────────────────┐
│  /ZE_2_Research  │  Research codebase
│        ↓         │  - Spawn specialized sub-agents
└──────────────────┘  - Document findings with file:line refs
         ↓
┌──────────────────┐
│  /ZE_3_Plan      │  Create implementation plan
│        ↓         │  - Break into verifiable phases
└──────────────────┘  - Separate automated vs manual checks
         ↓
┌──────────────────┐
│  /ZE_4_Execute   │  Implement ONE phase at a time
│        ↓         │  - Verify before proceeding
└──────────────────┘  - Document deviations
         ↓
┌──────────────────┐
│  /ZE_5_Verify    │  Validate implementation
└──────────────────┘  - Compare to plan
                      - Run automated checks
```

### Command Overview

| Command | Purpose | Inputs | Outputs |
|---------|---------|--------|---------|
| **ZE_1_Ticket** | Create structured tickets | User description | `thoughts/tickets/*.md` |
| **ZE_2_Research** | Research codebase | Ticket file | `thoughts/research/*.md` |
| **ZE_3_Plan** | Create implementation plan | Ticket + Research | `thoughts/plans/*.md` |
| **ZE_4_Execute** | Implement plan phases | Plan file | Updated plan with checkmarks |
| **ZE_5_Verify** | Verify implementation | Plan file | `thoughts/reviews/*.md` |

### Key Features

- **Structured Workflow** - Linear progression through well-defined phases
- **Interactive & Iterative** - Scope exploration, plan refinement, phased execution
- **Knowledge Accumulation** - Persistent memory in `thoughts/` directory
- **Quality Assurance** - Automated verification, manual checklists, deviation tracking

---

## Context Engineering in Practice

### Real-World Comparison

**❌ Single Agent Approach** (Context window fills with noise):
```
User Prompt
  → Glob() → Read(file1) → Read(file2) → Read(file3)
  → Edit()
  → Bash(build)
  → [800 warnings fill context]
  → Lost in the middle
```

**✅ Multi-Agent Approach** (Context stays clean):
```
User Prompt
  → Main Agent
  → Sub-agent: Find relevant files → Returns [file1, file2, file3]
  → Sub-agent: Research dependencies → Returns summary
  → Sub-agent: Research flows → Returns summary
  → Main Agent: Synthesizes summaries
  → Makes informed edit
  → Filtered build check
```

**Result: Context saved. Signal preserved. Quality maintained.**

### How Each Practice is Implemented

#### 1. Precision Filtering
- **Sub-agents with constrained tools** - Each agent only has read-only tools for their specific task
- **Filtered outputs** - Build success/failure instead of 800 warnings cluttering context
- **Actionable data only** - Research results contain file:line references, not entire codebases

#### 2. Hierarchical Summarization
- **Research phase** spawns multiple specialized sub-agents (locators, analyzers, pattern-finders)
- **Sub-agents process full files** - Main agent receives only summaries with specific references
- **Plans created from summaries** - Not from raw codebase exploration

#### 3. Advanced Retrieval
- **Multi-source search** - thoughts-locator finds historical context, codebase-locator finds current code
- **Phased retrieval** - Thoughts first (historical), then codebase (current), then patterns
- **Re-ranking through specialization** - Different agents for different retrieval tasks

#### 4. Contextual Scaffolding
- **Structured output formats** - Every command ends with consistent summary format
- **Clear schemas** - YAML frontmatter, markdown structure, success criteria separation
- **Guided workflows** - TodoWrite tool ensures agents follow structured steps

---

## Project Structure

```
ZE_Agentic_Demo/
├── .claude/
│   ├── agents/                    # 5 specialized sub-agent definitions
│   │   ├── codebase-analyzer.md
│   │   ├── codebase-locator.md
│   │   ├── codebase-pattern-finder.md
│   │   ├── thoughts-analyzer.md
│   │   └── thoughts-locator.md
│   │
│   └── commands/                  # 5 slash command workflows
│       ├── ZE_1_Ticket.md        # Ticket creation
│       ├── ZE_2_Research.md      # Codebase research
│       ├── ZE_3_Plan.md          # Implementation planning
│       ├── ZE_4_Execute.md       # Phase-by-phase execution
│       └── ZE_5_Verify.md        # Verification
│
├── docs/
│   └── ZE_ContextEngineering_Presentation.pdf
│
├── src/
│   └── TaskManagerApi/           # Demo C# application
│       ├── Models/
│       ├── Services/
│       └── Program.cs
│
└── thoughts/                      # Knowledge base
    ├── README.md                  # Comprehensive system documentation
    ├── tickets/                   # Work items (bugs, features, debt)
    ├── research/                  # Codebase analysis documents
    ├── plans/                     # Implementation specifications
    └── reviews/                   # Verification reports
```

---

## Best Practices

1. **Follow the workflow** - Each phase builds on the previous
2. **Be thorough in tickets** - Good tickets lead to good implementations
3. **Read files completely** - Never use limit/offset for implementation context
4. **One phase at a time** - ZE_4_Execute's stop-and-reinvoke is intentional
5. **Document deviations** - When reality differs from plan, explain why
6. **Update status** - Keep ticket status current throughout workflow
7. **Verify thoroughly** - Catch issues before production

---

## Documentation

### In This Repository

- **`.claude/commands/`** - Detailed documentation for each workflow command
- **`thoughts/README.md`** - Comprehensive guide to the knowledge base system
- **`src/TaskManagerApi/README.md`** - Demo application usage guide

### External Resources

- **Presentation**: `docs/ZE_ContextEngineering_Presentation.pdf`
- **Author LinkedIn**: [Zachary Etier](https://www.linkedin.com/in/zach-etier-a90b4840/)

---

## Acknowledgments

This work stands on the shoulders of giants:

- **Dex Horthy** - [HumanLayer](https://github.com/humanlayer/humanlayer)
  - [Building Multi-Agent Systems](https://www.youtube.com/watch?v=8kaMaTybvDUw)
  - [Context Engineering Patterns](https://www.youtube.com/watch?v=IS_y40zY-hc)
- **IndyDevDan** - [Claude Code Tutorials](https://www.youtube.com/@indydevdan)

---

## License

MIT License - Copyright (c) 2025 Zachary Etier

See full license text below or in [LICENSE](LICENSE) file.

<details>
<summary>Click to expand full license</summary>

```
MIT License

Copyright (c) 2025 Zachary Etier

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

</details>

---

## Contributing

This is an educational resource. Feel free to:
- ✅ Fork and adapt for your own workflows
- ✅ Submit issues for clarification or improvements
- ✅ Share your own Context Engineering patterns
- ✅ Create derivative works following the MIT license

**For students**: If you're using this after watching the presentation, start with `/ZE_1_Ticket` and work through the full workflow to see Context Engineering in action!

---

**Questions?** Open an issue or connect on [LinkedIn](https://www.linkedin.com/in/zach-etier-a90b4840/)
