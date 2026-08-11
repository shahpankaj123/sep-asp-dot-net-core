namespace dto;

public record TodoUpdateDto(
    int Id,
    string Title,
    bool IsCompleted
);