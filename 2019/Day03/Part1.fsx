#load "Lib.fs"

open System
open Lib

let rec generateVisits instruction currentTrip =
    let x, y = List.head currentTrip
    match instruction with
    | U(0) | L(0) | R(0) | D(0) -> currentTrip
    | U(steps) -> generateVisits (U(steps - 1)) ((x, y+1) :: currentTrip)
    | D(steps) -> generateVisits (D(steps - 1)) ((x, y-1) :: currentTrip)
    | L(steps) -> generateVisits (L(steps - 1)) ((x-1, y) :: currentTrip)
    | R(steps) -> generateVisits (R(steps - 1)) ((x+1, y) :: currentTrip)

let rec plotVisits visits instructions =
    match instructions with
    | [] -> (List.concat >> Set.ofList) visits
    | instruction::rest ->
        let lastVisited = (List.head >> List.head) visits
        let newlyVisitedList = generateVisits instruction [lastVisited]
        plotVisits (newlyVisitedList :: visits) rest

let firstList::secondList::_ = 
    IO.File.ReadAllLines("input/Day3.txt")
    |> List.ofArray
    |> List.map ((fun str -> str.Split ",") >> List.ofArray >> List.map toDirection >> plotVisits [[(0,0)]])

Set.intersect firstList secondList
|> Set.map (fun (x, y) -> Math.Abs(x) + Math.Abs(y)) 
|> Set.filter (fun x -> x > 0) 
|> Set.minElement
|> printfn "Answer is %A"