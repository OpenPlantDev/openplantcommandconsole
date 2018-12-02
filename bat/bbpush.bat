if not [%OP_MERGETOSTREAM%] == [] (
    echo bb -t %OP_MERGETOSTREAM% push -u --xstream
    bb -t %OP_MERGETOSTREAM% push -u --xstream
) 
else (
    echo MergeToStream is not defined for stream %TeamName%
)