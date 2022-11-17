import { Injectable } from "@nestjs/common";
import { DataSource, EntityTarget, ObjectLiteral } from "typeorm";

@Injectable()
export class EntityRepository {

    constructor(private dataSource: DataSource) {

    }

    async save<Entity extends ObjectLiteral>(target: EntityTarget<Entity>, instance: Entity) {
        const repo = this.dataSource.getRepository(target);
        await repo.save(instance);
    }

    async getAll<Entity extends ObjectLiteral>(target: EntityTarget<Entity>, pageIndex: number = undefined, pageSize: number = undefined): Promise<Entity[]> {
        const repo = this.dataSource.getRepository(target);
        if (pageIndex != null) {
            return await repo.find({ skip: pageIndex * pageSize, take: pageSize });
        }
        return await repo.find();
    }

    async getByKey<Entity extends ObjectLiteral>(target: EntityTarget<Entity>, idName: string, value: any, thowErrorIfNotFound = true): Promise<Entity> {
        const repo = this.dataSource.getRepository(target);
        const params = {};
        params[idName] = value;
        const item = await repo.findOneBy(params);
        return item;
    }

    async delete<Entity extends ObjectLiteral>(target: EntityTarget<Entity>, instance: Entity) {
        const repo = this.dataSource.getRepository(target);
        if (instance != null) {
            await repo.delete(instance);
        }
    }

}