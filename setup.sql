CREATE TABLE blogs(
  id INT NOT NULL AUTO_INCREMENT,
  title VARCHAR(80),
  author VARCHAR(80),
  content VARCHAR(255),
  isPublished TINYINT, 
  PRIMARY KEY (id)
)

INSERT INTO blogs (
  title, 
  author,
  content,
  isPublished
)

VALUES (
  "My first blog",
  "Miles F. Wilson", 
  "This is a story about Ikigai. It's the intersection of passion, mission, vocation, and profession.",
  true
)