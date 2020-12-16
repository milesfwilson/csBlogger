CREATE TABLE comments(
  id INT NOT NULL AUTO_INCREMENT,
  content VARCHAR(80),
  creatorId VARCHAR(255),
  blogId INT Not NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (creatorId)
      REFERENCES profiles2(id)
      ON DELETE CASCADE
)



-- CREATE TABLE comments(
--   id INT NOT NULL AUTO_INCREMENT,
--   content VARCHAR(80) NOT NULL,
--  blogId INT NOT NULL,
-- creatorId VARCHAR(255) NOT NULL, 
--   PRIMARY KEY (id),
--   FOREIGN KEY (creatorId)
--       REFERENCES profiles2(id)
--       ON DELETE CASCADE
-- )
-- INSERT INTO blogs (
--   title, 
--   author,
--   content,
--   isPublished
-- )

-- VALUES (
--   "My first blog",
--   "Miles F. Wilson", 
--   "This is a story about Ikigai. It's the intersection of passion, mission, vocation, and profession.",
--   true
-- )