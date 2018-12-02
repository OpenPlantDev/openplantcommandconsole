if not [%OP_MERGETOSTREAM%] == [] (
    echo bb -t %OP_MERGETOSTREAM% out
    bb -t %OP_MERGETOSTREAM% out
) else (
    echo MergeToStream is not defined for stream %TeamName%
)
