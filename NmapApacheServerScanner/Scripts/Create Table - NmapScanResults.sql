CREATE TABLE public.nmap_scan_results (
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	created TIMESTAMP NOT NULL DEFAULT NOW(),
	host VARCHAR(200) NOT NULL,
	tomcat_version VARCHAR(20) NULL,
	full_result JSON NOT NULL
);