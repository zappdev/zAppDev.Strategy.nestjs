import { AppConfig } from '@framework/app.config';
import { setConfig } from '@framework/config-helper';
import { NestFactory } from '@nestjs/core';
import { AppModule } from './app.module';

async function bootstrap(config: AppConfig) {
  setConfig(config);

  const app = await NestFactory.create(AppModule);
  //app.useLogger(app.get(WINSTON_MODULE_NEST_PROVIDER));
  await app.listen(config.port ?? 3000);
}


bootstrap({
  port: parseInt(process.env.PORT, 10) || 3000,
  database: {
    host: process.env.DB_HOST,
    database: process.env.DB_NAME,
    username: process.env.DB_USER,
    password: process.env.DB_PASSWORD,
    synchronize: true
  }
});
