#load "Lib.fs"

open Day2

let fixGravityAssist noun verb list =
    list |> updateAt 1 noun |> updateAt 2 verb

let cartesianProduct xs ys = [
    for x in xs do
    for y in ys do
    yield x, y
]

let allInputs = cartesianProduct [0..99] [0..99]

let attemptTry x y =
    startingCode
    |> fixGravityAssist x y
    |> processOpCodeAt 0
    |> List.item 0

allInputs
|> List.find (fun (x,y) -> (attemptTry x y) = 19690720)
|> (fun (noun,verb) -> 100 * noun + verb)
|> printfn "correct sum is %i" 