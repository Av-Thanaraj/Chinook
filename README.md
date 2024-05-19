Implemented service classes and interfaces to manage the domain logic using the dependency injection pattern.

Implemented Service Classes:


ArtistService: Handles artist-related domain logic. It contains the following methods:
 - GetArtistsAsync
 - GetArtistsByNameAsync


PlaylistService: Handles playlist-related domain logic. It contains the following methods:
 - CreateAsync
 - UpdateAsync
 - DeleteAsync
 - GetPlaylistByNameAsync
 - GetPlaylistsByUserIdAsync


UserPlaylistService: Handles UserPlaylist-related domain logic. It contains the following methods:
 - CreateAsync
 - UpdateAsync
 - GetByUserIdPlaylistIdAsync
