
# Contributing to PersianInputValidator

Thank you for your interest in contributing to PersianInputValidator.

از مشارکت شما در توسعه کتابخانه PersianInputValidator سپاسگزاریم.

## Reporting bugs

Before reporting a bug:

1. Check whether the issue has already been reported.
2. Describe the expected behavior.
3. Describe the actual behavior.
4. Include a minimal reproducible example when possible.
5. Mention the relevant .NET version and environment.

## Suggesting improvements

Feature suggestions should explain:

- The problem the feature solves.
- The expected behavior.
- Examples of valid and invalid input, where applicable.
- Any compatibility concerns.

## Making code changes

1. Fork the repository.
2. Create a branch for your change.
3. Keep changes focused and easy to review.
4. Add or update automated tests.
5. Ensure existing tests continue to pass.
6. Update documentation when public behavior changes.
7. Submit a pull request with a clear description.

## Coding guidelines

- Follow the existing C# style and project conventions.
- Keep public APIs focused and predictable.
- Handle null and empty input consistently with the documented contract.
- Avoid breaking existing behavior without a clear reason.
- Do not claim that format validation proves a real-world identity, account, phone number, or postal address exists.
- Do not introduce unnecessary dependencies.
- Document limitations and edge cases.

## Testing

Run the test suite from the repository root:

```bash
dotnet test tests/PersianInputValidator.Tests/PersianInputValidator.Tests.csproj
```

Changes should include tests for new functionality and relevant edge cases.

## Pull requests

A pull request should include:

- A concise summary of the change.
- The reason for the change.
- Tests performed.
- Documentation updates, if applicable.
- Any known limitations.

All contributions are subject to review. Passing automated tests does not automatically guarantee acceptance.

## License

By contributing, you agree that your contributions will be distributed under the repository's MIT License.
