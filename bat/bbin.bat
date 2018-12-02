if not [%OP_MERGETOSTREAM%] == [] (
    echo bb -t %OP_MERGETOSTREAM% in
    bb -t %OP_MERGETOSTREAM% in
) else (
    echo MergeToStream is not defined for stream %TeamName%
)
