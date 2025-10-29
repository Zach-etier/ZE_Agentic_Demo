# ZE Agentic Demo

A practical implementation of **Context Engineering** principles - demonstrating how to maximize signal and minimize noise in AI agent workflows through structured multi-agent orchestration.

> **📺 Companion Resource**: This repository accompanies the "Context Engineering" presentation by [Zachary Etier](https://www.linkedin.com/in/zach-etier-a90b4840/). See `docs/ZE_ContextEngineering_Presentation.pdf` for the full presentation.

## What is Context Engineering?

**Context Engineering** is the practice of maximizing signal and minimizing noise by deliberately curating a stream of concise, highly relevant information for an agent, rather than allowing the agent to passively consume data on its own.

This repository demonstrates the four core practices of Context Engineering:

1. **Precision Filtering** - Pass only critical, actionable data (e.g., processing errors, not all warnings)
2. **Hierarchical Summarization** - Use sub-agents to process dense documents, feed concise summaries to main agent
3. **Advanced Retrieval** - Implement dynamic search, re-rank results, query multiple sources
4. **Contextual Scaffolding** - Clear output schemas, guided problem-solving approach

## The "Lost in the Middle" Problem

AI agents suffer performance degradation when critical information is buried in the middle of the context window. This demo solves that through:

- **Sub-agent decomposition** - Breaking complex tasks into focused sub-tasks
- **Hierarchical summarization** - Condensing verbose outputs before presenting to main agent
- **Phased execution** - One step at a time to maintain context clarity
- **Structured workflows** - Consistent patterns that keep important information at context boundaries

## Overview

The ZE workflow demonstrates a systematic, multi-agent approach to software development - from problem identification through implementation and verification. It uses specialized Claude Code slash commands to orchestrate AI agents through each phase while maintaining clean, focused context.

## Workflow Phases

```
/ZE_1_Ticket    → Create structured tickets
     ↓
/ZE_2_Research  → Research codebase and patterns
     ↓
/ZE_3_Plan      → Create detailed implementation plans
     ↓
/ZE_4_Execute   → Implement one phase at a time
     ↓
/ZE_5_Verify    → Verify implementation quality
```

## Directory Structure

```
.
├── .claude/
│   └── commands/           # Slash command definitions
│       ├── ZE_1_Ticket.md
│       ├── ZE_2_Research.md
│       ├── ZE_3_Plan.md
│       ├── ZE_4_Execute.md
│       └── ZE_5_Verify.md
│
└── thoughts/              # Knowledge base and artifacts
    ├── tickets/          # Work items (bugs, features, debt)
    ├── research/         # Codebase analysis
    ├── plans/           # Implementation specs
    └── reviews/         # Verification reports
```

## Quick Start

### 1. Create a Ticket

Start any work by creating a structured ticket:

```bash
/ZE_1_Ticket thoughts "Add user authentication feature"
```

The command will interactively gather requirements and create a ticket in `thoughts/tickets/`.

### 2. Research the Codebase

Research how to implement the ticket:

```bash
/ZE_2_Research thoughts thoughts/tickets/feature_user_auth.md
```

This spawns specialized agents to analyze the codebase and create a research document in `thoughts/research/`.

### 3. Create an Implementation Plan

Develop a detailed plan based on research:

```bash
/ZE_3_Plan thoughts thoughts/tickets/feature_user_auth.md thoughts/research/2025-01-15_auth_patterns.md
```

Creates a phased implementation plan in `thoughts/plans/`.

### 4. Execute the Plan

Implement one phase at a time:

```bash
/ZE_4_Execute thoughts thoughts/plans/user-auth-implementation.md
```

After each phase completes, reinvoke the command to continue to the next phase.

### 5. Verify Implementation

Validate the implementation:

```bash
/ZE_5_Verify thoughts thoughts/plans/user-auth-implementation.md
```

Creates a verification report in `thoughts/reviews/`.

## Key Features

### Structured Workflow
- **Linear progression** through well-defined phases
- **Each phase builds** on the previous one
- **Clear handoffs** between phases with status updates

### Interactive and Iterative
- **Scope exploration** during ticket creation
- **Follow-up research** when questions arise
- **Plan refinement** through user feedback
- **One phase at a time** execution for quality

### Knowledge Accumulation
- **Persistent memory** in the `thoughts/` directory
- **Historical context** from previous research
- **Pattern discovery** through sub-agent analysis
- **Deviation tracking** when reality differs from plans

### Quality Assurance
- **Automated verification** (tests, linting, builds)
- **Manual verification** checklists
- **Deviation documentation** with rationale
- **Post-implementation reviews**

## Command Details

### ZE_1_Ticket
Creates comprehensive tickets through interactive questioning:
- Determines ticket type (bug, feature, debt)
- Explores scope boundaries iteratively
- Extracts keywords and patterns for research
- Defines success criteria

### ZE_2_Research
Conducts thorough codebase analysis:
- Spawns specialized sub-agents (locators, analyzers, pattern-finders)
- Searches historical context in `thoughts/`
- Documents findings with file:line references
- Identifies patterns and conventions

### ZE_3_Plan
Creates detailed implementation specifications:
- Interactive planning with user feedback
- Breaks work into verifiable phases
- Separates automated vs manual verification
- Resolves all open questions before finalizing

### ZE_4_Execute
Implements plans methodically:
- Executes ONE phase at a time
- Verifies each phase before proceeding
- Documents deviations from plan
- Updates progress with checkmarks

### ZE_5_Verify
Validates implementation quality:
- Compares implementation to plan
- Runs automated verification
- Assesses code quality
- Creates manual testing checklist

## Best Practices

1. **Follow the workflow** - Each phase builds on the previous
2. **Be thorough in tickets** - Good tickets lead to good implementations
3. **Read files completely** - Never use limit/offset for implementation context
4. **One phase at a time** - ZE_4_Execute's stop-and-reinvoke is intentional
5. **Document deviations** - When reality differs from plan, explain why
6. **Update status** - Keep ticket status current throughout workflow
7. **Verify thoroughly** - Catch issues before production

## Documentation

- **Command Details**: See `.claude/commands/` for detailed command documentation
- **Thoughts System**: See `thoughts/README.md` for knowledge base documentation

## Output Formats

Each command provides consistent, structured output with copy-paste commands for the next step:

```
✓ [Phase] Complete: [Name]

[Summary of what was accomplished]

NEXT STEP: [Description]
Copy and run: /ZE_[N]_[Command] [arguments]
```

This ensures smooth transitions between workflow phases.

## Context Engineering in Practice

This repository demonstrates Context Engineering principles through:

### 1. Precision Filtering
- **Sub-agents with constrained tools** - Each agent only has access to read-only tools for their specific task
- **Filtered outputs** - Build success/failure instead of 800 warnings cluttering context
- **Actionable data only** - Research results contain file:line references, not entire codebases

### 2. Hierarchical Summarization
- **Research phase** spawns multiple specialized sub-agents (locators, analyzers, pattern-finders)
- **Sub-agents process full files** - Main agent receives only summaries with specific references
- **Plans created from summaries** - Not from raw codebase exploration

### 3. Advanced Retrieval
- **Multi-source search** - thoughts-locator finds historical context, codebase-locator finds current code
- **Phased retrieval** - Thoughts first (historical), then codebase (current), then patterns
- **Re-ranking through specialization** - Different agents for different retrieval tasks

### 4. Contextual Scaffolding
- **Structured output formats** - Every command ends with consistent summary format
- **Clear schemas** - YAML frontmatter, markdown structure, success criteria separation
- **Guided workflows** - TodoWrite tool ensures agents follow structured steps

## Philosophy

The ZE workflow is designed around Context Engineering principles:
- **Signal over noise** - Sub-agents filter information before main agent sees it
- **Hierarchical processing** - Complex tasks decomposed into focused sub-tasks
- **Context preservation** - Thoughts directory maintains knowledge across sessions
- **Structured iteration** - Phased execution prevents context window pollution
- **Human-in-the-loop** - Strategic checkpoints for review and guidance

## Real-World Example

**Single Agent Approach** (Context window fills with noise):
```
User Prompt → Glob() → Read(file1) → Read(file2) → Read(file3)
→ Edit() → Bash(build) → [800 warnings fill context] → Lost in the middle
```

**Multi-Agent Approach** (Context stays clean):
```
User Prompt → Main Agent → Sub-agent: Find relevant files → Returns [file1, file2, file3]
Main Agent → Sub-agent: Research dependencies → Returns summary
Main Agent → Sub-agent: Research flows → Returns summary
Main Agent → Synthesizes summaries → Makes informed edit → Filtered build check
```

**Context saved. Signal preserved. Quality maintained.**

## Acknowledgments

This work stands on the shoulders of giants:

- **Dex Horthy** - [HumanLayer](https://github.com/humanlayer/humanlayer)
  - [Building Multi-Agent Systems](https://www.youtube.com/watch?v=8kaMaTybvDUw)
  - [Context Engineering Patterns](https://www.youtube.com/watch?v=IS_y40zY-hc)
- **IndyDevDan** - [Claude Code Tutorials](https://www.youtube.com/@indydevdan)

## License

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

## About the Author

**Zachary Etier**
- LinkedIn: [zach-etier-a90b4840](https://www.linkedin.com/in/zach-etier-a90b4840/)
- Presentation: See `docs/ZE_ContextEngineering_Presentation.pdf`

## Contributing

This is an educational resource. Feel free to:
- Fork and adapt for your own workflows
- Submit issues for clarification or improvements
- Share your own Context Engineering patterns
- Create derivative works following the MIT license

**For students**: If you're using this after watching the presentation, start with `/ZE_1_Ticket` and work through the full workflow to see Context Engineering in action!
