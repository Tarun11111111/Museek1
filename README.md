# Museek
## A full-stack music streaming web application with role-based access, CRUD management, discovery, search, and an in-page audio player

Museek is a Blazor Server–based music streaming platform built with ASP.NET Core, Entity Framework Core, and ASP.NET Identity. It simulates a real-world music application workflow where administrators manage the music catalog and users browse, discover, search, and play songs. The system is fully database-driven and integrates a JavaScript-powered audio player using Blazor JS interop.

---

## Project Overview

Museek was designed and implemented as an end-to-end full-stack application that mirrors how modern music streaming platforms operate.

Admins are responsible for maintaining the music catalog, while users focus on discovery, playback, and playlist interaction. All pages are data-driven, role-aware, and designed to scale as new features are added.

---

## Backend and Data Layer

- Designed domain entities and a normalized database structure for the music catalog and user features.
- Implemented Entity Framework Core with safe DbContext usage using `IDbContextFactory`, suitable for Blazor Server.
- Built relational links between core entities such as Song, Artist, and Album using foreign keys.
- Wrote database queries with joins to produce display-ready view models, for example combining Song data with Artist names for UI rendering.
- Ensured the database is the single source of truth for all application content.

---

## Authentication and Role Management

- Implemented authentication using ASP.NET Identity.
- Enforced role-based access control to clearly separate Admin and User capabilities.
- Used role checks in Razor components to conditionally render admin-only actions such as Create, Edit, and Delete.
- Ensured users only interact with features appropriate to their role.

---

## Admin Catalog Management

- Implemented full CRUD functionality for Song and Artist entities.
- Enhanced Song Edit, Delete, and Details pages to display Cover_Art using a consistent card-style preview.
- Followed real-world admin workflows by:
  - Selecting audio files from the `wwwroot/audios` directory.
  - Selecting cover images from the `wwwroot/images` directory.
  - Selecting Albums and Artists directly from the database using dropdowns.
- Maintained clean and predictable admin forms to prevent invalid data entry.

---

## External API Integration (Last.fm)

- Integrated the Last.fm API to enrich artist data.
- Used the API to retrieve artist metadata such as:
  - Artist name
  - Artist biography
- Designed the API feature as a helper tool rather than a replacement for the database.
- Allowed admins to use external data to speed up artist creation while keeping stored data consistent.
- Demonstrated real-world API consumption and data-mapping patterns.

---

## User Experience and UI Behavior

- Built responsive layouts using Razor components and scoped CSS.
- Implemented a Home page with dynamic sections such as:
  - Popular Songs
  - Trending Artists
  - New Releases
- Designed a modern card-based UI for songs, artists, and playlists.
- Ensured consistent styling across Admin and User views.

---

## Music Player System

- Implemented an in-page audio player inspired by real streaming platforms.
- Supported playback features:
  - Play and pause
  - Next and previous
  - Shuffle
  - Repeat off, repeat all, repeat one
- Managed playback queue, current song index, shuffle history, and repeat state in Blazor.
- Synchronized playback state with the HTML5 audio element using JavaScript interop.
- Used a `JSInvokable` callback to detect when a song ends and trigger the next action.
- Ensured the player appears only when a song is selected and resets cleanly when closed.

---

## Search and Discovery Features

### Live Song Search (Home Page)

- Implemented a live search experience that queries the database as the user types.
- Displayed results in a dropdown anchored under the search bar.
- Each result shows:
  - Song cover art
  - Song title
  - Artist name
- Implemented stale request protection so fast typing does not display outdated results.
- Enabled click-to-play directly from search results.
- Built a playback queue that:
  - Merges database search results with existing song lists.
  - Deduplicates songs using audio file paths.
- Refined search UI to use compact horizontal rows instead of large square cards.

### Artist Search (Planned and Partially Implemented)

- Planned to reuse the same dropdown search pattern on the Artists page.
- Intended behavior:
  - Search artists by name.
  - Display artist profile picture and name.
  - Navigate to the selected artist’s albums page on click, matching existing artist navigation behavior.

---

## Installation for Users

Museek is a web application.

- End users do not install the application locally.
- If deployed, this section should include:
  - A live demo URL.
  - Demo credentials for both Admin and User roles.

---

## Installation for Contributors

### Prerequisites

- .NET SDK matching the project target framework.
- SQL Server or the configured database provider.

### Setup Steps

1. Clone the repository.
2. Restore NuGet packages.
3. Configure the database connection string in `appsettings.json` or user secrets.
4. Apply Entity Framework Core migrations.
5. Ensure `wwwroot` contains required assets:
   - `audios` folder for audio files.
   - `images` folder for song cover art.
   - `Artist Profile Images` folder if used.
6. Run the project locally.

---

## Contributor Expectations

- Use short, clear commit messages with a focused scope, for example:  
  `feat: add live song search dropdown`
- Do not mix UI refactors with feature logic in a single commit.
- Add or update scoped CSS when modifying UI components.
- Test both Admin and User flows before submitting changes.
- Follow existing component and styling patterns for consistency.

---

## Known Issues and Next Steps

### Known Issues

- Users can only search for songs that already exist in the system and were added by admins.
- Search functionality is not yet implemented across all pages.

### Next Steps

- Implement real user authentication using Google OAuth for registration and login.
- Build a complete public API to retrieve songs, playlists, albums, and artists for both admins and users.
- Integrate more advanced external music APIs for richer and more complete data.
- Enhance UI design further with more modern layouts, animations, and interaction patterns.
