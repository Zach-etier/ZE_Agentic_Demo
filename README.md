# ZE Agentic Demo

A demonstration of the ZE Agentic Development workflow - a structured approach to software development using AI agents.

## Overview

The ZE workflow provides a systematic process for handling software development tasks from initial problem identification through implementation and verification. It uses specialized Claude Code slash commands to guide AI agents through each phase.

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

## Philosophy

The ZE workflow is designed for:
- **Thoroughness over speed** - Understand before implementing
- **Quality over quantity** - One phase done right beats many done poorly
- **Documentation over memory** - Persistent knowledge in `thoughts/`
- **Iteration over perfection** - Refine through feedback loops
- **Automation with oversight** - AI agents with human guidance

## License

[Add your license here]

## Contributing

[Add contribution guidelines here]
