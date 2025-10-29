# Thoughts Directory

## Overview

The `thoughts/` directory is your project's knowledge base, containing all documentation, tickets, research, plans, and reviews. It serves as persistent memory for both human developers and AI agents, tracking the entire lifecycle of work from problem identification through implementation and verification.

## Directory Structure

```
thoughts/
├── tickets/         # Work items (bugs, features, technical debt)
├── research/        # Codebase analysis and findings
├── plans/          # Implementation specifications
└── reviews/        # Post-implementation validation
```

## The ZE Workflow

The ZE Agentic Development workflow follows a linear progression:

```
/ZE_1_Ticket    → thoughts/tickets/[type]_[subject].md
     ↓
/ZE_2_Research  → thoughts/research/[date]_[topic].md
     ↓
/ZE_3_Plan      → thoughts/plans/[descriptive-name].md
     ↓
/ZE_4_Execute   (implements one phase at a time, updates plan with checkmarks)
     ↓
/ZE_5_Verify    → thoughts/reviews/[plan-name]-review.md
```

Each phase builds on the previous, ensuring thorough understanding before implementation.

---

## Directory Details

### tickets/

**Created by**: `/ZE_1_Ticket`
**Purpose**: Structured tickets that serve as the foundation for research and planning.

**Ticket Types**:
- `bug` - Something broken, unexpected behavior, errors
- `feature` - New functionality or enhancement
- `debt` - Technical debt, refactoring, code cleanup, architecture improvements

**File Naming**: `[type]_[subject].md`
- Examples: `bug_login_validation.md`, `feature_user_dashboard.md`, `debt_auth_refactor.md`

**Structure**:
- Description and context
- Functional and non-functional requirements
- Current vs desired state
- Research context (keywords, patterns to investigate)
- Success criteria (automated and manual)

**Status Lifecycle**:
1. `open` - Created by ZE_1_Ticket
2. `researched` - Updated by ZE_2_Research
3. `planned` - Updated by ZE_3_Plan
4. `implemented` - Updated by ZE_4_Execute
5. `reviewed` - Updated by ZE_5_Verify

**Key Features**:
- Interactive scope exploration with user
- Extracts keywords and patterns for research phase
- Establishes clear boundaries of what IS and ISN'T included

---

### research/

**Created by**: `/ZE_2_Research`
**Purpose**: Comprehensive codebase analysis documenting how systems work and where components are located.

**File Naming**: `[date]_[topic].md`
- Examples: `2025-01-15_authentication_patterns.md`, `2025-01-20_api_architecture.md`

**Structure**:
- YAML frontmatter with metadata (date, git info, tags)
- Ticket synopsis
- Summary of high-level findings
- Detailed findings by component (with file:line references)
- Code references (specific paths and locations)
- Architecture insights (patterns, conventions, design decisions)
- Historical context from other thoughts documents
- Open questions (areas needing further investigation)

**Research Process**:
The command spawns specialized sub-agents in phases:
1. **thoughts-locator** - Finds historical context in thoughts/
2. **thoughts-analyzer** - Extracts insights from found documents
3. **codebase-locator** - Finds files and components in codebase
4. **codebase-analyzer** - Analyzes how specific code works
5. **codebase-pattern-finder** - Finds similar implementations to model after

**Follow-up Research**:
Research documents can be updated with follow-up sections when new questions arise. The `last_updated` and `last_updated_note` frontmatter fields track these updates.

---

### plans/

**Created by**: `/ZE_3_Plan`
**Used by**: `/ZE_4_Execute`
**Purpose**: Detailed implementation specifications breaking work into phases with specific changes and success criteria.

**File Naming**: `[descriptive-name].md`
- Examples: `user-authentication-implementation.md`, `dashboard-analytics-feature.md`

**Structure**:
- Overview and implementation approach
- Current state analysis (what exists, constraints discovered)
- Desired end state (specification and verification method)
- What we're NOT doing (explicit out-of-scope items)
- Implementation phases (sequential, each with):
  - Overview of what the phase accomplishes
  - Changes required (specific file modifications with code snippets)
  - Success criteria:
    - **Automated Verification**: Commands that can be run automatically
    - **Manual Verification**: Steps requiring human testing
- Testing strategy
- Performance considerations
- Migration notes (if applicable)
- References (ticket, research, similar implementations)

**Execution Tracking**:
Plans are updated during execution with:
- Checkmarks `[x]` for completed phases
- "Deviations from Plan" section documenting necessary changes with rationale
- "Implementation Complete" section when all phases done

**Important Notes**:
- Plans should have NO open questions - all decisions made before execution
- Each phase should be independently verifiable
- Success criteria must be specific and measurable
- ZE_4_Execute implements ONE phase at a time, then stops for reinvocation

---

### reviews/

**Created by**: `/ZE_5_Verify`
**Purpose**: Post-implementation validation verifying plans were executed correctly and documenting what was implemented.

**File Naming**: `[plan-name]-review.md`
- Examples: `user-authentication-implementation-review.md`, `dashboard-analytics-feature-review.md`

**Structure**:
- Implementation status (phase-by-phase completion)
- Automated verification results (build, tests, linting)
- Code review findings:
  - What matches the plan
  - Deviations from plan (with assessment of justification)
  - Potential issues discovered
- Manual testing checklist
- Recommendations for improvements

**Validation Process**:
1. Read the implementation plan
2. Identify what should have changed
3. Verify actual changes match the plan
4. Run automated verification commands
5. Document deviations and issues
6. Create manual testing checklist

**Review Outcomes**:
- No critical issues → Proceed with merge/deploy
- Minor issues → Address warnings and suggestions
- Critical issues → Fix and re-run verification
- Manual testing needed → Complete checklist before deploy

---

## File Naming Conventions

### Timestamps
Use ISO date format: `YYYY-MM-DD` (e.g., `2025-01-15`)

### Descriptive Names
- Use kebab-case: `user-authentication-plan.md`
- Be specific: `oauth-google-implementation.md`
- Avoid generic names: ~~`plan1.md`~~, ~~`research.md`~~

### Type Prefixes (for tickets)
- `bug_` for bug fixes
- `feature_` for new features
- `debt_` for technical debt/refactoring

---

## Frontmatter Standards

Research documents use YAML frontmatter:

```yaml
---
date: 2025-01-15T10:30:00Z
git_commit: abc123def456
branch: feature/oauth
repository: my-app
topic: "Google OAuth Implementation"
tags: [research, codebase, auth, oauth]
last_updated: 2025-01-15
---
```

Tickets use simplified frontmatter:

```yaml
---
type: feature
priority: high
created: 2025-01-15T10:30:00Z
status: open
tags: [auth, security]
keywords: [oauth, authentication, jwt]
patterns: [middleware, error handling]
---
```

---

## Search Behavior

### How AI Agents Search Thoughts

1. **thoughts-locator**: Finds relevant documents by keywords/patterns
2. **thoughts-analyzer**: Deep dives into specific documents for insights
3. **Research integration**: Findings inform codebase research strategy

### Search Priority

Research agents search in this order:
1. **research/** - Recent analysis and findings
2. **plans/** - Implementation history and patterns
3. **reviews/** - Post-implementation learnings
4. **tickets/** - Context about requirements

---

## Common Patterns

### Feature Development Flow
```
tickets/feature_oauth.md
  ↓ (research phase)
research/2025-01-15_oauth-patterns.md
  ↓ (planning phase)
plans/oauth-implementation.md
  ↓ (execution phase - one phase at a time)
plans/oauth-implementation.md (updated with checkmarks)
  ↓ (verification phase)
reviews/oauth-implementation-review.md
```

### Bug Investigation Flow
```
tickets/bug_memory_leak.md
  ↓
research/2025-01-16_memory-analysis.md
  ↓
plans/memory-leak-fix.md
  ↓
reviews/memory-leak-fix-review.md
```

### Technical Debt Flow
```
tickets/debt_auth_refactor.md
  ↓
research/2025-01-20_auth-system.md
  ↓
plans/auth-refactor.md
  ↓
reviews/auth-refactor-review.md
```

---

## Best Practices

### Creating Tickets
- Use interactive scope exploration to establish clear boundaries
- Extract specific keywords for research phase
- Define both automated and manual success criteria
- Be thorough in requirements gathering

### Conducting Research
- Always read mentioned files FULLY (no limit/offset)
- Use file:line references in all findings
- Spawn specialized sub-agents in parallel for efficiency
- Update with follow-up research when questions arise

### Writing Plans
- Resolve ALL open questions before finalizing
- Break into atomic, verifiable phases
- Separate automated vs manual success criteria
- Include "What We're NOT Doing" section

### Executing Plans
- Implement ONE phase at a time
- Verify each phase before proceeding
- Document deviations with clear rationale
- Update plan with checkmarks as you go

### Verifying Implementation
- Run all automated checks
- Compare actual changes to plan
- Assess deviations for justification
- Create thorough manual testing checklist

---

## Integration with Commands

Each command in the ZE workflow interacts with thoughts/:

| Command | Reads From | Writes To | Updates |
|---------|-----------|-----------|---------|
| `/ZE_1_Ticket` | - | `tickets/` | Creates ticket with status: open |
| `/ZE_2_Research` | `tickets/`, all `thoughts/` | `research/` | Updates ticket status: researched |
| `/ZE_3_Plan` | `tickets/`, `research/` | `plans/` | Updates ticket status: planned |
| `/ZE_4_Execute` | `plans/`, `tickets/`, `research/` | - | Updates plan progress, ticket status: implemented |
| `/ZE_5_Verify` | `plans/` | `reviews/` | Updates ticket status: reviewed |

---

## Tips for Effective Usage

1. **Follow the workflow**: Each phase builds on the previous - don't skip steps
2. **Be specific**: Use file:line references, specific commands, concrete examples
3. **Update status**: Keep ticket status current as it flows through phases
4. **Document deviations**: When reality differs from plan, document why
5. **Iterate on research**: Add follow-up sections when new questions arise
6. **One phase at a time**: ZE_4_Execute stops after each phase - this is intentional
7. **Verify thoroughly**: ZE_5_Verify catches issues before production

---

## Related Documentation

See `.claude/commands/` for detailed command documentation:
- `ZE_1_Ticket.md` - Ticket creation process
- `ZE_2_Research.md` - Research methodology
- `ZE_3_Plan.md` - Planning approach
- `ZE_4_Execute.md` - Implementation execution
- `ZE_5_Verify.md` - Verification process
