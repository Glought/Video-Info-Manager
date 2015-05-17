/*Video Info Manager for easy storage and copying of Video Descriptions and Tags.
  Copyright 2015 ThoughtsOfGlought

  This file is part of Video Info Manager.
  Video Info Manager is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  Video Info Manager is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with Video Info Manager.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace Video_Info_Manager
{
    public class VideoInfo
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public string Tags { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}