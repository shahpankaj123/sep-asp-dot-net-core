namespace dto;

public record TodoCreateDto(
    string Title,
    bool IsCompleted,
    int Id
);