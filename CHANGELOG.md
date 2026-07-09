# WolfTaming Plus — Changelog

In-game changes made on top of upstream [G3rste/wolftaming](https://github.com/G3rste/wolftaming) `@a596f65` (5.0.26 baseline).

Compare against upstream to see the full diff:
```bash
git diff a596f65..HEAD -- WolfTaming/
```

---

## 5.1.0 — 2026-06-25

**Commit:** `HEAD` — finalizes the `feature/toy-rework-textures-naming` branch.

### Docs
- **Rewrote README.md** with full WolfTaming Plus branding, features list, and disclaimers.

### Chore
- **Rebranded mod** from `"Wolf taming"` to `"WolfTaming Plus"` in `modinfo.json`.
- **Version bump:** `5.0.27` → `5.1.0` to reflect the new fork identity.
- **Updated handbook text** in `en.json` to reference WolfTaming Plus.
- **Added Shepherd skin variant 5** (`dog-shepherd-5`).

---

## 5.0.27 — 2026-06-24

**Commit:** `57752d2 feat: update tamed animal textures`

### Feat
- **Refreshed entity textures** for all tamed-animal variants (corgi, hunting hound, shepherd). The noise pass is now baked into the main texture.

---

## 5.0.26 — 2026-06-24 (baseline)

**Commit:** `7786ef4 feat: port 5.0.26 modifications from unzipped zip into source`

This is the initial port — every change below was previously sitting in the unzipped `wolftaming_v5.0.1` working copy and is now in the source tree.

### Feat
- **Chewing bone replaced the old dog toy.** The throwable item is now a vanilla `Item` wired to the petai `PetAIChewingBoneAimThrow` behavior, so aim, throw, durability, and the dog-notify all go through the same chain petai already supports. The dog fetch AI still lives in wolftaming source.
  - New: `durability: 150`, `shelvable`, `displaycaseable` (with a transform so it sits nicely on a shelf or in a display case).

### Fix
- **Chewing bone recipe uses red meat instead of dry grass.** `drygrass` previously made a 3×3 of hay bales the natural recipe, which felt off for a "bone" toy. The ingredient is now `game:redmeat-raw`.

### Chore
- **Dropped the pekingese/peach variant.** The peach entity, its armor/backpack/collar/helmet/scarf configs, and the related shepherding rule are all gone. The pekingese was a one-off model for one contributor and no longer fits the mod's direction. **A pekingese is no longer tamerable.**

### Localization
Renamed display strings in `WolfTaming/assets/wolftaming/lang/en.json` (other languages fall back to en). Reverted/overrode some upstream renames to better match what the user has been playing with:

| Key | Upstream 5.0.26 | Our 5.0.26 |
| --- | --- | --- |
| `item-creature-dog-wolf-male` | Wolfdog (male) | **Tamed wolf (male)** |
| `item-creature-dog-wolf-female` | Wolfdog (female) | **Tamed wolf (female)** |
| `item-creature-dog-wolf-pup` | Wolfdog (pup) | **Tamed wolf (pup)** |
| `item-dead-creature-dog-wolf-*` (×3) | Dead wolfdog (...) | **Dead tamed wolf (...)** |
| `item-creature-dog-hunting-male` | Hunting dog (male) | **Hunting hound (male)** |
| `item-creature-dog-hunting-female` | Hunting dog (female) | **Hunting hound (female)** |
| `item-creature-dog-hunting-pup` | Hunting dog (pup) | **Hunting hound (pup)** |
| `item-dead-creature-dog-hunting-*` (×3) | Dead hunting dog (...) | **Dead hunting hound (...)** |
| `item-creature-dog-shepherd-male` | German shepherd (male) | **Shepherd (male)** |
| `item-creature-dog-shepherd-female` | German shepherd (female) | **Shepherd (female)** |
| `item-creature-dog-shepherd-pup` | German shepherd (pup) | **Shepherd (pup)** |
| `item-dead-creature-dog-shepherd-*` (×3) | Dead german shepherd (...) | **Dead shepherd (...)** |
| `item-dogtoy` | Dog toy | **Chewing bone** |
| `itemdesc-dogtoy` | Throw it! Your dog will love it. | **A tamed wolf or hound will chase it when thrown** |

Plus a new block of `creature-wolftaming:dog-*-selectionbox-{BackPackAP,ArmorAP,HelmetAP,CollarAP}` keys (`"Bags"`, `"Body armor"`, `"Helmet"`, `"Collar"`) for the dog-attribute selection UI.

---

## Baseline bump — 2026-06-24

**Commit:** `b87be80 chore: set wolftaming baseline to 5.0.26`

- `WolfTaming/modinfo.json`: `"version": "5.0.1"` → `"5.0.26"`. The starting point of the user's unzipped working copy was 5.0.1; this bumps the source to 5.0.26 to match the working state before the port. The texture commit above then bumps to **5.0.27**.

---

## Summary of what changed vs upstream

| Area | Change |
| --- | --- |
| Chewing bone | vanilla `Item` + petai `PetAIChewingBoneAimThrow`, durability 150, shelvable, displaycaseable, recipe uses red meat |
| Pekinese/peach variant | removed everywhere — no longer tamerable |
| Display strings | reverted upstream renames (`Wolfdog`→`Tamed wolf`, `Hunting dog`→`Hunting hound`, `German shepherd`→`Shepherd`, `Dog toy`→`Chewing bone`) |
| Selection box labels | new `Bags` / `Body armor` / `Helmet` / `Collar` strings for the dog-attribute UI |
| Entity textures | refreshed (corgi, hunting hound, shepherd); noise pass baked into the main texture |
