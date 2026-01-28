package com.studentmanagement.app.config;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class DatabaseConfig {
    private String dbUrl;
    private String dbUsername;
    private String dbPassword;
    private String dbHost;
    private String dbPort;
}
