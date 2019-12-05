#load "Lib.fs"

open System
open Lib

let rec generateVisits instruction currentTrip =
    let ((x, y), currentStep) = List.head currentTrip
    match instruction with
    | U(0) | L(0) | R(0) | D(0) -> currentTrip
    | U(steps) -> generateVisits (U(steps - 1)) (((x, y+1), currentStep + 1) :: currentTrip)
    | D(steps) -> generateVisits (D(steps - 1)) (((x, y-1), currentStep + 1) :: currentTrip)
    | L(steps) -> generateVisits (L(steps - 1)) (((x-1, y), currentStep + 1) :: currentTrip)
    | R(steps) -> generateVisits (R(steps - 1)) (((x+1, y), currentStep + 1) :: currentTrip)

let rec plotVisits visits instructions =
    match instructions with
    | [] -> List.concat visits
    | instruction::rest ->
        let lastVisited = (List.head >> List.head) visits
        let newlyVisitedList = generateVisits instruction [lastVisited]
        plotVisits (newlyVisitedList :: visits) rest

let visitsToSet visits = visits |> List.map (fun ((x,y),_) -> (x,y)) |> Set.ofList

let firstList::secondList::_ = 
    IO.File.ReadAllLines("input/Day3.txt")
    |> List.ofArray
    |> List.map ((fun str -> str.Split ",") >> List.ofArray >> List.map toDirection >> plotVisits [[((0,0), 0)]])

let intersections = Set.intersect (visitsToSet firstList) (visitsToSet secondList)
let intersectionsA = Seq.map (fun intersect -> List.find (fun (visit, _) -> visit = intersect) firstList) intersections
let intersectionsB = Seq.map (fun intersect -> List.find (fun (visit, _) -> visit = intersect) secondList) intersections

List.concat [List.ofSeq intersectionsA; List.ofSeq intersectionsB]
|> List.groupBy (fun (visit, _) -> visit)
|> List.map (fun (_, place) -> List.sumBy (fun (_, step) -> step) place)
|> List.filter (fun x -> x > 0) 
|> List.min
|> printfn "Answer is %A"