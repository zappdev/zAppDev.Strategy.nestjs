import { AppConfig } from "./app.config";

let activeConfig: AppConfig = null;

export function setConfig(userConfig: AppConfig): void {
    activeConfig = { ...userConfig };
}

export function getConfig(): Readonly<AppConfig> {
    return activeConfig;
}