ALTER TABLE "public"."tz_project_person" DROP CONSTRAINT "fkey_person_project";
ALTER TABLE "public"."tz_project_person" DROP CONSTRAINT "FK_tz_project_person_project_id";
DROP TABLE IF EXISTS "public"."tz_person";
DROP TABLE IF EXISTS "public"."tz_project";
DROP TABLE IF EXISTS "public"."tz_project_person";
CREATE TABLE "public"."tz_person" ( 
  "id" SERIAL,
  "person_name" VARCHAR(25) NOT NULL,
  CONSTRAINT "tz_person_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."tz_project" ( 
  "id" SERIAL,
  "project_name" VARCHAR(50) NOT NULL,
  CONSTRAINT "tz_project_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."tz_project_person" ( 
  "id" SERIAL,
  "project_id" INTEGER NOT NULL,
  "person_id" INTEGER NOT NULL,
  "hours" INTEGER NOT NULL,
  CONSTRAINT "tz_project_person_pkey" PRIMARY KEY ("id")
);
INSERT INTO "public"."tz_person" ("person_name") VALUES ('Sara');
INSERT INTO "public"."tz_person" ("person_name") VALUES ('alex');
INSERT INTO "public"."tz_person" ("person_name") VALUES ('Alice');
INSERT INTO "public"."tz_person" ("person_name") VALUES ('Mira');
INSERT INTO "public"."tz_person" ("person_name") VALUES ('Honeylyn');
INSERT INTO "public"."tz_person" ("person_name") VALUES ('Henna');
INSERT INTO "public"."tz_person" ("person_name") VALUES ('Robin');
INSERT INTO "public"."tz_project" ("project_name") VALUES ('Project Alpha');
INSERT INTO "public"."tz_project" ("project_name") VALUES ('cv project');
INSERT INTO "public"."tz_project" ("project_name") VALUES ('backend');
INSERT INTO "public"."tz_project" ("project_name") VALUES ('Java ');
INSERT INTO "public"."tz_project" ("project_name") VALUES ('HTML CSS');
INSERT INTO "public"."tz_project" ("project_name") VALUES ('Bank Application');
INSERT INTO "public"."tz_project" ("project_name") VALUES ('Database');
INSERT INTO "public"."tz_project" ("project_name") VALUES ('LINQ');
INSERT INTO "public"."tz_project" ("project_name") VALUES ('PHP advance');
INSERT INTO "public"."tz_project_person" ("project_id", "person_id", "hours") VALUES (1, 1, 7);
INSERT INTO "public"."tz_project_person" ("project_id", "person_id", "hours") VALUES (2, 3, 6);
ALTER TABLE "public"."tz_project_person" ADD CONSTRAINT "fkey_person_project" FOREIGN KEY ("person_id") REFERENCES "public"."tz_person" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."tz_project_person" ADD CONSTRAINT "FK_tz_project_person_project_id" FOREIGN KEY ("project_id") REFERENCES "public"."tz_project" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
