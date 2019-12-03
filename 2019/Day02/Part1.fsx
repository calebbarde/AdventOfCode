#load "Lib.fs"

open Day2

let fixGravityAssist list = list |> updateAt 1 12 |> updateAt 2 2

startingCode
|> fixGravityAssist
|> processOpCodeAt 0
|> List.item 0
|> printfn "zero element is %i" 