-- CREATE TABLE profiles (
--   id VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   picture VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id)
-- )

CREATE TABLE comments(
  id INT NOT NULL AUTO_INCREMENT,
  content VARCHAR(80) NOT NULL,
 blogId INT NOT NULL,
creatorId VARCHAR(255) NOT NULL, 
  PRIMARY KEY (id),
  FOREIGN KEY (creatorId)
      REFERENCES profiles(id)
      ON DELETE CASCADE
)