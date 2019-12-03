module Day2

open System

let startingCode = 
    IO.File.ReadAllText("input/Day2.txt").Split(",") 
    |> List.ofArray 
    |> List.map Convert.ToInt32

let updateAt index value list = 
    List.mapi (fun k v -> if k = index then value else v) list

let rec processOpCodeAt index intCode  =
    let _, rest = List.splitAt index intCode
    let opCode::firstArg::secondArg::outputIndex::_ = rest
    match opCode with
    | 99 -> intCode
    | 1 -> 
        let firstVal = List.item firstArg intCode
        let secondVal = List.item secondArg intCode
        processOpCodeAt (index + 4) (updateAt outputIndex (firstVal + secondVal) intCode)
    | 2 -> 
        let firstVal = List.item firstArg intCode
        let secondVal = List.item secondArg intCode
        processOpCodeAt (index + 4) (updateAt outputIndex (firstVal * secondVal) intCode)
    | _ -> failwith "Should not have gotten here"