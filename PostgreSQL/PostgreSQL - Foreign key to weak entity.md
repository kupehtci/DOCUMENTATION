#PostgreSQL 

When having an instance that points or has a relation with an entity that is weak [[Weak Relationship]] so need to have 2 or more primary keys to be identified as unique

In order to point to them, the reference needs to be to both of the unique primary key identifiers as following: 

```PostgreSQL
CREATE TABLE table1 (
  id1  integer
, t1   bool NOT NULL DEFAULT true CHECK (t1)
, col1 text
, CONSTRAINT t1_uni_for_mixed_fk UNIQUE (id1, t1)
);

CREATE TABLE table2 (
  id2  integer PRIMARY KEY
, t2   bool NOT NULL DEFAULT true CHECK (t2)
, col2 text
, CONSTRAINT t2_uni_for_mixed_fk UNIQUE (id2, t2)
);

CREATE TABLE table3 (
  id3  integer PRIMARY KEY
, t3   bool NOT NULL DEFAULT true CHECK (t3)
, col3 text
, CONSTRAINT t3_uni_for_mixed_fk UNIQUE (id3, t3)
);

CREATE TABLE child (
  child_id integer GENERATED ALWAYS AS IDENTITY PRIMARY KEY
, mix_id integer NOT NULL
, t1 bool
, t2 bool
, t3 bool  
, CONSTRAINT max_one_source CHECK (num_nonnulls(t1, t2, t3) < 2)
-- , CONSTRAINT exactly_one_source CHECK num_nonnulls(t1, t2, t3) = 1  -- or this?
, CONSTRAINT child_mix_id1_fk FOREIGN KEY (mix_id, t1) REFERENCES table1 (id1, t1)
, CONSTRAINT child_mix_id2_fk FOREIGN KEY (mix_id, t2) REFERENCES table2 (id2, t2)
, CONSTRAINT child_mix_id3_fk FOREIGN KEY (mix_id, t3) REFERENCES table3 (id3, t3)
);
```

In this example, table1, table2 and table3 have two primary keys and this ones can be referenced in the constrain in the child table. 