# To do: Gobblet Game

Try to organize this pls 

## Scripts

- [ ] ~~after placing an object on board, generate new if needed~~ _too hard.._ just make the side platform bigger and put all the avalible pieces on there _for now_
  - standard easy: 3 small, 2 mid, 1 large
- [ ] fix smooth moving the piece
- [ ] reset func after game over (pop up with who won -> restart/quit?)

## UI

- [ ] menu with choice of 3x3 or 4x4 board
- [ ] side menu in game for exiting
- [ ] game over message

## Content

- [ ] materials + highlight variants
- [ ] could make the container in blender for quicker customization

## Docs

what I used so far (outside of labs):

- ~~[Pointer Events](https://www.youtube.com/watch?v=kkkmX3_fvfQ&list=WL&index=28&ab_channel=Andrew)~~ (went back to using mouse events)
- [Game Manager Base](https://www.youtube.com/watch?v=o0A5cS9cQNc&ab_channel=BaconDev)

## Done (just to have on file)

- [x] save a piece's size somewhere? for checking is you can place over it (maybe a Scriptable Object thing?)
- [x] rename board square objects to something that makes more sense
- [x] fix X highlight while hovering (after added asset)
- [x] rename EventClick to smth like 'selecting object'
- [x] add restriction based on turn X/O
- [x] add script SelectingBoardPlacement
    - [x] when active highlight squares on board -> when you click on a square it moves the selected object to that square
    - [x] reset material after moving piece
    - [x] block if currently selected smaller than object on square
- [x] add ~~script GameLogic~~ put in BoardManager? that checks if anyone won