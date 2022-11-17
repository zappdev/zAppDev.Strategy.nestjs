export interface AppConfig {
    port: number,
    database: {
        host: string,
        port?: number,
        username: string,
        password: string,
        database: string,
        synchronize?: boolean
    }
}