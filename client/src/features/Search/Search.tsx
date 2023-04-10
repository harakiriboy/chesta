import React, { useState } from "react";
import "./Search.css";

const Search = () => {
  const [searchQuery, setSearchQuery] = useState("");
  const [selectedTags, setSelectedTags] = useState<string[]>([]);

  const handleSearchInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearchQuery(e.target.value);
  };

  const handleTagClick = (tag: string) => {
    if (selectedTags.includes(tag)) {
      setSelectedTags(selectedTags.filter((t) => t !== tag));
    } else {
      setSelectedTags([...selectedTags, tag]);
    }
  };

  return (
    <div className="search-page">
      <h1>Search Page</h1>
      <div className="search-container">
        <input
          type="text"
          placeholder="Search"
          value={searchQuery}
          onChange={handleSearchInputChange}
        />
        <button>Search</button>
      </div>
      <div className="tag-picker">
        <h2>Select Tags:</h2>
        <div className="tag-list">
          <span
            className={selectedTags.includes("Tag1") ? "selected" : ""}
            onClick={() => handleTagClick("Tag1")}
          >
            Tag1
          </span>
          <span
            className={selectedTags.includes("Tag2") ? "selected" : ""}
            onClick={() => handleTagClick("Tag2")}
          >
            Tag2
          </span>
          <span
            className={selectedTags.includes("Tag3") ? "selected" : ""}
            onClick={() => handleTagClick("Tag3")}
          >
            Tag3
          </span>
        </div>
      </div>
    </div>
  );
};

export default Search;