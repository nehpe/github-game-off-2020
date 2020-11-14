# Astrogate

A game for the github game-off 2020 edition

## Synopsis of the game

The game will be a sort of "multi-genre" style game, based in space.

Space is to relate to the theme, where moonshot is a "shot at the moon", with
some other definitions.

The game will contain two different "modes", or styles of play.

The objective of the game will be to conquer the galaxy. This will be time
boxed into a tripartite, or three parts.

Part 0: Place your space station
Part 1: Conquer the surrounding planets and rob them of minerals / resources
Part 2: Defend your galaxy against other galactic empires
Part 3: Expand your galactic empire

## TODOs - Initial MVP

- [X] Map movement (with WASD)
- [ ] Randomly generated planets
- [ ] Place space station
      - [ ] What does this look like?
- [ ] UI section
- [ ] Draw connections

## TODOs - Nice to Haves

- [ ] Map movement (with mouse)
- [ ] Sound effects
      - [ ] Attack
      - [ ] Select
      - [ ] Place
- [ ] Music
      - [ ] Intro / Menu
      - [ ] Play scene
      - [ ] Dark mode track (danger)
- [ ] Procedurally generated star background

## Flow States

Flow is controlled by a "State" inside the global Game State object.

### Phase -1: Pre-Start

Generate a background of stars

### Phase 0: Initial

Initial placement of home base

This is where we place your initial "home base"

This will require a cursor to aim where this is placed.

Once this is placed then we will genearte the map of the planets.

We should generate a background of stars before this.

### Phase 1: Expansion

Attack and connect planets to get resources

Every X resources gets you 1 ship (which are useful for expanding)

### Phase 2: Defend (Stretch)

Be attacked / AI
