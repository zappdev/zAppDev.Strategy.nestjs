import { Module } from '@nestjs/common';
import { ConfigModule } from '@nestjs/config';
import { TypeOrmModule } from '@nestjs/typeorm';
import { getConfig } from '@framework/config-helper';
import { persistedEntities } from '@entity/index';
import { serviceControllers } from './api/exposed';
import { serviceServices } from '@service/exposed';
import { EntityRepository } from '@framework/service/entityRepository.service';

@Module({
  imports: [
    ConfigModule.forRoot({
      isGlobal: true,
      envFilePath: ['.env.local', '.env'],
    }),
    TypeOrmModule.forRootAsync({
      useFactory: async () => {
        const dbConfig = getConfig().database;

        return {
          type: "mysql",
          host: dbConfig.host,
          port: dbConfig.port ?? 3306,
          username: dbConfig.username,
          password: dbConfig.password,
          database: dbConfig.database,
          entities: [...persistedEntities],
          synchronize: dbConfig.synchronize ?? true,
          logging: false //|| process.env.NODE_ENV == "development"
        };
      }
    })
  ],
  controllers: [...serviceControllers],
  providers: [EntityRepository, ...serviceServices],
})
export class AppModule { }
